using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10.0f;
    public float maxSpeed = 15.0f;
    public float rotationSpeed = 360.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddRelativeForce(movement * speed);

        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity = clampedVelocity;
    }
}