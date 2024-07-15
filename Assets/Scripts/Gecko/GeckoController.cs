using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeckoController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] LayerMask groundLayer;

    // Move around
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float walkingRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walkAround();
    }

    void walkAround() {
        if (!walkpointSet) {
            searchForDestination();
        }
        if (walkpointSet) {
            agent.SetDestination(destPoint);
            animator.Play("Armature_Walking");
        }
        if(Vector3.Distance(transform.position, destPoint) < 2) {
                walkpointSet = false;
                animator.Play("Armature_Idle");
        }
    }

    void searchForDestination() {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
