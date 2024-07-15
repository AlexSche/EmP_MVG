using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeckoController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] LayerMask groundLayer;
    Vector3 destPoint;
    
    [SerializeField] float walkingRange = 9;
    private bool isIdling = false;
    private bool isLookingForDestination;
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
        if (isLookingForDestination) {
            searchForDestination();
        }
        if (!isLookingForDestination && !(Vector3.Distance(transform.position, destPoint) < 0.5f)) {
            agent.SetDestination(destPoint);
            animator.SetBool("isWalking", true);
        }
        if(Vector3.Distance(transform.position, destPoint) < 0.5f) {
            if (!isIdling) {
            isIdling = true;
            StartCoroutine(startIdlingForSeconds(6f));
            }   
        }
    }

    void searchForDestination() {
        float z = Random.Range(-walkingRange, walkingRange);
        float x = Random.Range(-walkingRange, walkingRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            isLookingForDestination = false;
        }
    }

    private IEnumerator startIdlingForSeconds(float waitTime) {
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(waitTime);
        isLookingForDestination = true;
        isIdling = false;
    }
}
