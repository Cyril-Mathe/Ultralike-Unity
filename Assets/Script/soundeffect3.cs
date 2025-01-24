using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffect3 : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    public AudioSource src;
    public AudioClip sfx3;

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
        src.clip = sfx3;
        src.Play();
    }

    private void Update()
    {
        Die();
    }
}
