using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Contol
{
    public class PlayerController : MonoBehaviour
    {
        Fighter fighter;

        void Start()
        {
            fighter = GetComponent<Fighter>();
        }

        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>(); 
                if (combatTarget == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(combatTarget);  
                }
                 return true ;
            }
            return false;
        }

        bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit == true)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        void MoveToCursor()
        {
        
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}