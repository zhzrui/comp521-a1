using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawn;

    private GameObject activeProjectile;
    private int projectilesOnHand = 0;


    public void OnFire(InputValue value)
    {
        Debug.Log("ON FIRE CALLED");

        if (value.isPressed)
        {
            Fire();
        }
    }
    private void Fire()
    {
        // if no projectile on hand
        if (projectilesOnHand <= 0)
        {
            Debug.Log("no projectiles");
            return;
        }
        
        // "only one projectile can be in flight at one time"
        if (activeProjectile != null)
        {
            Debug.Log("projectile still active");
            return;
        }

        activeProjectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation); // spawning projectile

        projectilesOnHand--; //firing the projectiles
        Debug.Log("projectiles on hand: " + projectilesOnHand);
    }

    public void AddProjectiles()
    {
        projectilesOnHand++;
        Debug.Log("projectiles available: " + projectilesOnHand);
    }

    public void ResetProjectiles()
    {
        projectilesOnHand = 0;
        Debug.Log("resetting projectiles to 0");
    }
}
