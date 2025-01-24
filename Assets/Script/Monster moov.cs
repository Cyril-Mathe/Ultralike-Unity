using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float moveSpeed = 3f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.position = targetPosition;
            transform.LookAt(player);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}