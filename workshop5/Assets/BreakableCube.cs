using UnityEngine;

public class BreakableCube : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            rb.isKinematic = false; 
            rb.AddExplosionForce(200f, collision.contacts[0].point, 5f); 
        }
    }
}
