using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f; // Ilo�� zadawanych obra�e�
    public float attackCooldown = 1.5f; // Czas mi�dzy atakami
    private float lastAttackTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerHealth = GameObject.Find("Player").GetComponent<PlayerStats>();
            playerHealth.TakeDamage(damage);
        }
    }
}
