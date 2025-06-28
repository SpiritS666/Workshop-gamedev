using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody Rigidbodyrb;
    public float Speed = 5.0f;
    public float RotationSpeed = 100.0f;
    public float MaxHeight = 1.5f;

    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float sideInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        float currentHeight = transform.position.y;

        if (currentHeight >= MaxHeight && forwardInput > 0)
        {
            forwardInput = 0f;
        }

        Vector3 force = transform.forward * forwardInput * Speed;
        Rigidbodyrb.AddForce(force, ForceMode.Force);

        float rotation = sideInput * RotationSpeed * Time.fixedDeltaTime;
        Quaternion turnOffset = Quaternion.Euler(0, rotation, 0);
        Rigidbodyrb.MoveRotation(Rigidbodyrb.rotation * turnOffset);
    }
}
