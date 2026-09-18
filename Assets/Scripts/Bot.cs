using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float botSpeed = 1.5f;
    private Platform platform;
    private FoodPellet targetPellet;

    private bool initialized = false;

    public void Initialize(Platform platform)
    {
        this.platform = platform;
        initialized = true;

        Debug.Log("bot initialized on platform: " + platform.PlatformNumber);

        ChooseTargetPellet();
    }

    // bot picks random pellet
    private void ChooseTargetPellet()
    {
        if (platform.FoodPellets.Count == 0)
        {
            targetPellet = null;
            return;
        }

        int randomPellet = Random.Range(0, platform.FoodPellets.Count); // get 0 to available pellets

        targetPellet = platform.FoodPellets[randomPellet]; // set target pellet to the random pellet
    }

    // moving
    private void botMove()
    {
        // bot should not be moving on y
        Vector3 targetPosition = targetPellet.transform.position;
        targetPosition.y = transform.position.y; // keep at current height

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, botSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < 0.2f)
        {
            targetPellet.ConsumedByBot();
            targetPellet = null;
        }
    }

    private void Update()
    {
        //Debug.Log("bot update");

        if (initialized == false)
        {
            return;
        }

        if (targetPellet == null)
        {
            ChooseTargetPellet();
            return;
        }
        botMove();

    }

}
