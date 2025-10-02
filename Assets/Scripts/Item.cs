using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ProjectilePoolSO pool;
    public float speed = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void SetPool(ProjectilePoolSO poolSO)
    {
        pool = poolSO;
    }
    private void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        rb.linearVelocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // Destroy(collision.gameObject);
            if (pool != null)
            {
                pool.ReturnToPool(gameObject);
            }
        }

    }
    private void OnDisable()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}