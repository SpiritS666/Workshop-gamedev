using UnityEngine;

public class RigidbodyMod : MonoBehaviour
{
    private Rigidbody _rb;
    private Renderer _renderer;

    private bool activated = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        if (_rb == null) Debug.LogError("Rigidbody not found on object.");
        if (_renderer == null) Debug.LogWarning("Renderer not found, color will not change.");
    }

    void Update()
    {
        if (!activated && Input.GetKeyDown(KeyCode.Space))
        {
            activated = true;
            _rb.mass = 1.0f;
            _rb.linearDamping = 0;
            _rb.angularDamping = 0.05f;
            _rb.useGravity = true;
            _rb.AddForce(Vector3.up * 300f);
            if (_renderer != null) _renderer.material.color = Color.green;
            Debug.Log("Activated: the object has jumped.");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_renderer != null)
                _renderer.material.color = new Color(Random.value, Random.value, Random.value);
            Debug.Log("Color changed.");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localScale *= 1.2f;
            Debug.Log("Object scaled up.");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale *= 0.8f;
            Debug.Log("Object scaled down.");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Hello! This is a message from the living object.");
        }
    }
}