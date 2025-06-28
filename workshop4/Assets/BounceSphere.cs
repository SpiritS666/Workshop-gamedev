using UnityEngine;

public class BounceSphere : MonoBehaviour
{
    public string finishTag = "Finish";
    public float bounceVelocityY = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(finishTag))
        {
            Vector3 v = rb.velocity;
            v.y = Mathf.Abs(bounceVelocityY);
            rb.velocity = v;
        }
    }
}
