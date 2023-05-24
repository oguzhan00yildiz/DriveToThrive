using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowScript : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nMesh;
    public bool isFollowing;
    public float distance;
    public GameObject car;
    public bool canFollow = false;
    public static FollowScript instance;
    // Start is called before the first frame update
    void Start()
    {
        nMesh = GetComponent<NavMeshAgent>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, car.transform.position);
        Follow();
    }
    void Follow()
    {
        if(distance < 10f && !Target.instance.isDead)
        {
            nMesh.destination = player.position;
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }
    }
}
