using UnityEngine;

public class StopSphere : MonoBehaviour
{
    [SerializeField] private string finishTag = "Finish";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(finishTag))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;      
                rb.angularVelocity = Vector3.zero; 
                rb.isKinematic = true;            
            }
        }
    }
}
