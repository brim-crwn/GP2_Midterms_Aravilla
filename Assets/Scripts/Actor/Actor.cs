using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    Rigidbody rb;

    private GameObject player;
    public string bulletTag = "Bullet";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject otherObj = collision.gameObject;
        Renderer myRenderer = GetComponent<Renderer>();
        Renderer otherRenderer = otherObj.GetComponent<Renderer>();

        if (otherObj.CompareTag(bulletTag))
        {
            if (myRenderer != null && otherRenderer != null)
            {
                // Compare material colors
                if (myRenderer.material.color == otherRenderer.material.color)
                {
                    // Destroy the incoming object and this object
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                if (myRenderer.material.color != otherRenderer.material.color)
                {
                    // Destroy the incoming object and this object
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
