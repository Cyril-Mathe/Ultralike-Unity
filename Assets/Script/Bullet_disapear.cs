using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;

    void Start()
    {
        // Détruit uniquement l'instance de la balle
        Destroy(this.gameObject, lifeTime);
    }
}