using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet touché a un composant EnemyHealth
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // Détruit le projectile après l'impact
        }
    }
}