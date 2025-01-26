using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 10;         // Iloœæ obra¿eñ zadawanych przeciwnikowi
    public float lifetime = 5f;    // Czas ¿ycia pocisku (zniknie po tym czasie, jeœli nie trafi)
    public GameObject impactEffect; // Efekt cz¹steczkowy po trafieniu (opcjonalny)

    private bool canDamage;
    void Start()
    {
        // Zniszczenie pocisku po okreœlonym czasie
        Destroy(gameObject, lifetime);
        canDamage = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzenie, czy pocisk uderzy³ w przeciwnika
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

        // Uruchomienie efektu trafienia (jeœli przypisany)
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        // Zniszczenie pocisku po kolizji
        Destroy(gameObject);
    }
}
