using UnityEngine;

public class WandController : MonoBehaviour
{
    public GameObject[] projectilePrefabs; // Tablica prefabów pocisków
    public Transform spawnPoint;          // Punkt, z którego będą wystrzeliwane pociski
    public float projectileSpeed = 20f;   // Prędkość pocisku
    public float cooldown = 0.5f;         // Czas odnowienia między strzałami

    private int currentProjectileIndex = 0; // Indeks aktualnie wybranego pocisku
    private float lastShotTime;

    void Update()
    {
        // Strzelanie pociskiem
        if (Input.GetButtonDown("Fire1") && Time.time - lastShotTime >= cooldown)
        {
            ShootProjectile();
            lastShotTime = Time.time;
        }

        // Zmiana typu pocisku (przewijanie do przodu)
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeProjectile(1);
        }

        // Zmiana typu pocisku (przewijanie do tyłu)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeProjectile(-1);
        }
    }

    private void ShootProjectile()
    {
        // Upewnij się, że wybrano prawidłowy prefab
        if (projectilePrefabs.Length > 0 && projectilePrefabs[currentProjectileIndex] != null)
        {
            // Utwórz pocisk w punkcie spawn
            GameObject projectile = Instantiate(
                projectilePrefabs[currentProjectileIndex],
                spawnPoint.position,
                spawnPoint.rotation
            );

            // Nadaj pociskowi prędkość
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.forward * projectileSpeed;
            }
        }
        else
        {
            Debug.LogWarning("Brak przypisanego prefab pocisku!");
        }
    }

    private void ChangeProjectile(int direction)
    {
        // Zmień indeks pocisku, biorąc pod uwagę długość tablicy prefabów
        currentProjectileIndex = (currentProjectileIndex + direction + projectilePrefabs.Length) % projectilePrefabs.Length;
        Debug.Log("Zmieniono pocisk na: " + projectilePrefabs[currentProjectileIndex].name);
    }
}
