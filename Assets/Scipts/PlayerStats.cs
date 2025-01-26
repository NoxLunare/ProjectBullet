using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider healthSlider;
    public float currentHealth;
    public float maxHealth = 100f;
    public EnemySpawner maxEnemies;
    public GameObject panelFinalny;
    public GameObject sliderHealth;
    public GameObject panelScore;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        Debug.Log("Player took damage. Current health: " + currentHealth);
        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        maxEnemies.maxEnemies = 0;
        panelFinalny.SetActive(true);
        panelScore.SetActive(false);
        sliderHealth.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
