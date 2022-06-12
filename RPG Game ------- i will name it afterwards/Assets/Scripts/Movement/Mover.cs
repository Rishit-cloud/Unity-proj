using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Combat;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navMeshAgent;
        Animator animator;
        Fighter fighter;
 
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
        }

        void Update()
        {
            // if (Input.GetMouseButton(0))
            // {
            //     MoveToCursor();
            // }
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
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
