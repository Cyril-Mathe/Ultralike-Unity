using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Vous pouvez ajouter des effets de particules ici
        // Exemple : Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        // Détruit l'objet enemy
        Destroy(gameObject);
    }
}
