using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float enemyHealth = 100f;

        public void TakeDamage(float playerDamage)
        {
            enemyHealth = Mathf.Max(enemyHealth - playerDamage, 0);
            Debug.Log(enemyHealth);
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
