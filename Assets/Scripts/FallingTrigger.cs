using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManager>().Lose();
        }
    }
}
