using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public static float kickForce = 20f;

    private AudioSource kick;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);
        kick = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("PLAYER"))//.tag == "Player")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rb.AddForce(-direction * kickForce, ForceMode.Impulse);
            kick.Play();
        }
    }
}
