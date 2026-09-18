using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private Platform platform;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Debug.Log("player on platform");

            PlayerPlatform playerPlatform = other.GetComponent<PlayerPlatform>();

            if (playerPlatform != null)
            {
                //Debug.Log("found playerplatform");
                playerPlatform.EnterPlatform(platform);
            }

            platform.PlayerEntered();
        }
    }
}
