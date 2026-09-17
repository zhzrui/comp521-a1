using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    private Platform currentPlatform;

    public Platform CurrentPlatform
    {
        get 
        {
            return currentPlatform;
        }
    }

    public void EnterPlatform(Platform platform)
    {
        if (currentPlatform == platform)
        {
            return;
        }

        currentPlatform = platform;
        //Debug.Log("current platform: " + platform.PlatformNumber);
    }
}
