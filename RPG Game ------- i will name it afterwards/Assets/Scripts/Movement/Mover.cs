using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
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

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            fighter.Cancel();
            MoveTo(destination);
        }
        
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
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
