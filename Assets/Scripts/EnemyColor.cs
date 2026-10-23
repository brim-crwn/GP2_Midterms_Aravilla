using UnityEngine;

public class EnemyColor : MonoBehaviour, IDamageable
{
    public Color enemyColor;

    private Renderer enemyRenderer;

    [SerializeField] private int scoreValue = 10;

    public Color DamageColor =>
        enemyRenderer != null
            ? enemyRenderer.material.color
            : enemyColor;

    private void Awake()
    {
        enemyRenderer = GetComponent<Renderer>();

        if (enemyRenderer != null)
        {
            enemyColor = enemyRenderer.material.color;
        }
    }

    public void TakeDamage()
    {
        if (GM.Instance != null)
        {
            GM.Instance.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}
