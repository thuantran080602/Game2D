using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public class BossController : MonoBehaviour
    {
        public float maxhp = 100f;
        private float currentHealth;

        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = maxhp;
            healthBar.SetNewHp(maxhp);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            healthBar.SetNewHp(maxhp);

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            // Xử lý khi Boss bị hạ gục
            // ...
            Destroy(gameObject);
        }
    }

    public class PlayerController : MonoBehaviour
    {
        public float damage = 10f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Boss"))
            {
                BossController boss = other.GetComponent<BossController>();
                if (boss != null)
                {
                    boss.TakeDamage(damage);
                }
            }
        }
    }
}
