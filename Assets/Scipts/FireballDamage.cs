using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public int damage = 2;         // Ilo�� obra�e� zadawanych w jednej iteracji
    public float damageDuration = 5f; // Czas trwania zadawania obra�e�
    public float damageInterval = 1f; // Interwa� mi�dzy obra�eniami
    public float lifetime = 5f;    // Czas �ycia pocisku (zniknie po tym czasie, je�li nie trafi)
    public GameObject impactEffect; // Efekt cz�steczkowy po trafieniu (opcjonalny)

    private bool hasHit = false; // Czy pocisk ju� trafi� w przeciwnika

    void Start()
    {
        // Zniszczenie pocisku po okre�lonym czasie
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzenie, czy pocisk uderzy� w przeciwnika
        if (collision.gameObject.CompareTag("Enemy") && !hasHit)
        {
            // Pobranie komponentu zdrowia przeciwnika
            ZombieHealth enemyHealth = collision.gameObject.GetComponent<ZombieHealth>();
            if (enemyHealth != null)
            {
                // Rozpocz�cie zadawania obra�e�
                StartCoroutine(DealDamageOverTime(enemyHealth));
            }

            // Oznaczenie pocisku jako "trafionego", aby nie wywo�ywa� tej logiki wielokrotnie
            hasHit = true;

            // Uruchomienie efektu trafienia (je�li przypisany)
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

        // Zadawanie obra�e� co okre�lony interwa� przez czas trwania
        while (elapsed < damageDuration)
        {
            enemyHealth.TakeDamage(damage); // Zadaj obra�enia
            yield return new WaitForSeconds(damageInterval); // Poczekaj przed kolejnym zadaniem obra�e�
            elapsed += damageInterval;
        }
    }
}
