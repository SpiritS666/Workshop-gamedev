using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    AudioSource bulletSound; //NEW
    public float BulletVelocity = 20f;

    void Start()
    {
        bulletSound = GetComponent<AudioSource>(); //NEW
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(
                BulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity =
                transform.forward * BulletVelocity;

            bulletSound.Play(); //NEW
        }
    }
}