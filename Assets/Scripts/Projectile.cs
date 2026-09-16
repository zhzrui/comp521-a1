using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    // projectiles destroy tree or wtv they hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject); // other
    }
}
