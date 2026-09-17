using UnityEngine;

public class PelletTrigger : MonoBehaviour
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
            else
            {
                Debug.Log("could not find playerplatform");
            }

            platform.PlayerEntered();
        }
    }
}
