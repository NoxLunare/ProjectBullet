using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public int damage = 2;         // Iloœæ obra¿eñ zadawanych w jednej iteracji
    public float damageDuration = 5f; // Czas trwania zadawania obra¿eñ
    public float damageInterval = 1f; // Interwa³ miêdzy obra¿eniami
    public float lifetime = 5f;    // Czas ¿ycia pocisku (zniknie po tym czasie, jeœli nie trafi)
    public GameObject impactEffect; // Efekt cz¹steczkowy po trafieniu (opcjonalny)

    private bool hasHit = false; // Czy pocisk ju¿ trafi³ w przeciwnika

    void Start()
    {
        // Zniszczenie pocisku po okreœlonym czasie
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzenie, czy pocisk uderzy³ w przeciwnika
        if (collision.gameObject.CompareTag("Enemy") && !hasHit)
        {
            // Pobranie komponentu zdrowia przeciwnika
            ZombieHealth enemyHealth = collision.gameObject.GetComponent<ZombieHealth>();
            if (enemyHealth != null)
            {
                // Rozpoczêcie zadawania obra¿eñ
                StartCoroutine(DealDamageOverTime(enemyHealth));
            }

            // Oznaczenie pocisku jako "trafionego", aby nie wywo³ywaæ tej logiki wielokrotnie
            hasHit = true;

            // Uruchomienie efektu trafienia (jeœli przypisany)
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            // Zniszczenie pocisku po kolizji
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator DealDamageOverTime(ZombieHealth enemyHealth)
    {
        float elapsed = 0f;

        // Zadawanie obra¿eñ co okreœlony interwa³ przez czas trwania
        while (elapsed < damageDuration)
        {
            enemyHealth.TakeDamage(damage); // Zadaj obra¿enia
            yield return new WaitForSeconds(damageInterval); // Poczekaj przed kolejnym zadaniem obra¿eñ
            elapsed += damageInterval;
        }
    }
}
