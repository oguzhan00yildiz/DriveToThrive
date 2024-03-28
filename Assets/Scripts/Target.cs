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
    public Animator animator;

    void Start()
    {
        instance = this;
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        ParticleSystem bloodParticle= Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(bloodParticle, 1f);

        if(health <= 0 && !isDead)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            animator.SetBool("isAttacking", true);
            IDamageable damageable = CarHealth.instance;
            float damageAmount = Random.Range(10f, 20f);
            damageable?.TakeDamage(damageAmount);
            //isAttacking = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            animator.SetBool("isAttacking", false);
            //isAttacking = false;
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
