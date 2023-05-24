using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    private float health = 100f;
    [SerializeField] private ParticleSystem blood;
    public bool isDead = false;
    public bool isAttacking = false;
    public static Target instance;

    void Start()
    {
        instance = this;
    }
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        blood.Play();

        if(health <= 0)
        {
            isDead = true;
            Destroy(gameObject, 5f);
        }
        else
        {
            isDead = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            isAttacking = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            isAttacking = false;
        }
    }
    /* void Attack()
    {
        if(FollowScript.instance.distance <= 5f)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    } */
   
}
