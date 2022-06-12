using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        float weaponRange = 2f;
        Transform target;
        Mover mover;
        Animator animator;
        [SerializeField] float attackSpeed = 1;
        float timeSinceLastAttack = 0;

        void Start()
        {
            mover = GetComponent<Mover>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (!NewMethod())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Cancel();

                //AutoAttackBehaviour();
                ManualAttackBehaviour();
            }
        }

        void AutoAttackBehaviour()
        {
            if (timeSinceLastAttack > attackSpeed)
            {
                animator.SetTrigger("isAttacking");
                timeSinceLastAttack = 0;
            }
        }

        void ManualAttackBehaviour()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (timeSinceLastAttack > attackSpeed)
                {
                    animator.SetTrigger("isAttacking");
                    timeSinceLastAttack = 0;
                }
            }
        }

        private bool NewMethod()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            // GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        // this is a animation event
        void Hit()
        {
            
        }
    }

}
