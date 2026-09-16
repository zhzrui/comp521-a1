using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawn;

    private GameObject existingProjectile;

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Fire();
        }
    }
    private void Fire()
    {
        // "only one projectile can be in flight at one time"
        if (existingProjectile != null)
        {
            return;
        }

        existingProjectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation); // spawning projectile
    }
}
