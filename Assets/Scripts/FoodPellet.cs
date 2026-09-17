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
            Debug.Log("collected pellet");
            Destroy(gameObject);
        }
    }

}
