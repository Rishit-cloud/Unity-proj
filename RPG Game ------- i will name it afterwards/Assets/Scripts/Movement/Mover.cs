using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
 
    void Update()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     MoveToCursor();
        // }
        UpdateAnimator();
    }

    

    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
    }

    void UpdateAnimator()
    {
        float fullSpeed = 7.88f;
        float walkSpeed = 5.66f;
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("ForwardSpeed", speed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            navMeshAgent.speed = fullSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            navMeshAgent.speed = walkSpeed;
        }
    }
}
}
