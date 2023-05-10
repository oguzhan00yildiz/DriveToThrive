using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    private float health = 100f;
    [SerializeField] private ParticleSystem blood;
    public void TakeDamage(float damage)
    {
        health -= damage;
        blood.Play();

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
