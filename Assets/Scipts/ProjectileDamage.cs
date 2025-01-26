using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 10;         // Ilo�� obra�e� zadawanych przeciwnikowi
    public float lifetime = 5f;    // Czas �ycia pocisku (zniknie po tym czasie, je�li nie trafi)
    public GameObject impactEffect; // Efekt cz�steczkowy po trafieniu (opcjonalny)

    private bool canDamage;
    void Start()
    {
        // Zniszczenie pocisku po okre�lonym czasie
        Destroy(gameObject, lifetime);
        canDamage = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzenie, czy pocisk uderzy� w przeciwnika
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Pobranie komponentu zdrowia przeciwnika
            ZombieHealth enemyHealth = collision.gameObject.GetComponent<ZombieHealth>();
            if (enemyHealth != null && canDamage)
            {
                enemyHealth.TakeDamage(damage);
                canDamage=false;
            }
        }

        // Uruchomienie efektu trafienia (je�li przypisany)
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        // Zniszczenie pocisku po kolizji
        Destroy(gameObject);
    }
}
