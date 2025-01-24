using UnityEngine;


// Script de comportement des ennemis
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
            // Déplacement vers le joueur
            transform.position = Vector3.MoveTowards(transform.position, 
                player.position, moveSpeed * Time.deltaTime);
            
            // Rotation vers le joueur
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