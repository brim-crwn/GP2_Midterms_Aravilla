using UnityEngine;

public abstract class Actor : MonoBehaviour, IDamageable
{
    [SerializeField] protected float speed = 1f;
    private Rigidbody rb;

    [SerializeField] private int ScoreValue = 10;

    private GameObject player;
    public string bulletTag = "Bullet";

    public Color enemyColor;
    private Renderer enemyRenderer;

    public Color DamageColor =>
        enemyRenderer != null
            ? enemyRenderer.material.color
            : enemyColor;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
        }

        enemyRenderer = GetComponent<Renderer>();

        if (player == null)
        {
            Debug.LogWarning("Player object not found.");
        }
    }

    protected virtual void Update()
    {
        if (player == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            speed * Time.deltaTime
        );
    }

    protected virtual void Awake()
    {
        enemyRenderer = GetComponent<Renderer>();

        if (enemyRenderer != null)
        {
            enemyColor = enemyRenderer.material.color;
        }
    }

    public virtual void TakeDamage()
    {
        if (GM.Instance != null)
        {
            GM.Instance.AddScore(ScoreValue);
        }

        Destroy(gameObject);
    }
}
