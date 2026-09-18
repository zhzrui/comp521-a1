using UnityEngine;

public class FoodPellet : MonoBehaviour
{
    private Platform platform;

    public Platform PelletPlatform
    {
        get
        {
            return platform;
        }
    }

    // dynamic instantiation
    public void Initialize(Platform platform)
    {
        this.platform = platform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting shooting = other.GetComponent<PlayerShooting>();
            
            if (shooting != null)
            {
                shooting.AddProjectiles();
                //Debug.Log("shooting - collected pellet");
            }

            platform.RemoveFoodPellet(this);

            Destroy(gameObject);
        }
    }


    public void ConsumedByBot()
    {
        platform.RemoveFoodPellet(this);
        Destroy(gameObject);
    }
}
