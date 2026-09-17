using UnityEngine;

public class TreeObject : MonoBehaviour
{
    private Platform platform;

    // "If it encounters a tree on the same platform both it and the tree are removed"
    // just in case: assign platform to tree so that if player platform != tree platform, tree is not destroyed
    public Platform TreePlatform
    {
        get 
        {
            return platform;
        }
    }

    private void Awake()
    {
        platform = GetComponentInParent<Platform>();

        if (platform == null)
        {
            Debug.LogError("tree - platform not found");
        }
    }

}
