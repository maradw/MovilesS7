using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField]
    private SimpleObjectPooling obstacleType;
    [SerializeField] private Rigidbody myRigidbody;

    private bool isSetUp;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") )
        {
            Debug.Log("Enemy collide");
            isSetUp = false;
            obstacleType.ObjectReturn(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collide");
            isSetUp = false;
            obstacleType.ObjectReturn(this.gameObject);
        }
    }
    public void HandleClicked()
    {
        Debug.Log("Enemy was clicked!");
        isSetUp = false;
        obstacleType.ObjectReturn(this.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSetUp = false;
            obstacleType.ObjectReturn(this.gameObject);
        }
    }

    private void OnEnable()
    {
        obstacleType.onEnableObject += SetUp;
        SetUp(); // Garantiza que la velocidad se aplique al activarse desde el pool
    }

    private void OnDisable()
    {
        obstacleType.onEnableObject -= SetUp;
    }

    private void SetUp()
    {
        if (!isSetUp)
        {
            if (myRigidbody == null)
            {
                myRigidbody = GetComponent<Rigidbody>();
            }

            if (myRigidbody != null)
            {
                myRigidbody.linearVelocity = Vector3.left * speed;
            }

            isSetUp = true;
        }
    }
}