using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        float weaponRange = 2f;
        Transform target;
        Mover mover;

        void Start()
        {
            mover = GetComponent<Mover>();
        }

        void Update()
        {
            if (target == null) return;
            if (!NewMethod())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Stop();
            }
        }

        private bool NewMethod()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }

}
