using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(
            direction.normalized * distanceThisFrame,
            Space.World
        );

        transform.LookAt(target);
    }


    void HitTarget()
    {
        IDamageable damageable =
            target.GetComponentInParent<IDamageable>();

        BulletColor bulletColor = GetComponent<BulletColor>();

        if (damageable != null && bulletColor != null)
        {
            // Compare the bullet's color with the enemy's color.
            if (damageable.DamageColor == bulletColor.CurrentColor)
            {
                damageable.TakeDamage();
                Debug.Log("Same color! Enemy destroyed.");
            }
            else
            {
                Debug.Log("Different colors! Enemy survives.");
            }
        }

        // Destroy the bullet regardless of whether the colors match.
        Destroy(gameObject);
    }

}
