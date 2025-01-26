using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;

    private EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (spawner != null)
        {
            spawner.EnemyDied();
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddPoint();
        }

        Destroy(gameObject);
    }
}
