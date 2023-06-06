using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorScript : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("isRunning", FollowScript.instance.isFollowing);
        //animator.SetBool("isDead", Target.instance.isDead);
        //animator.SetBool("isAttacking",Target.instance.isAttacking);
    }
}
