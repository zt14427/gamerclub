using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    private float openForce = 10.0f;

    [SerializeField]
    AudioSource ting;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger entered: " + other.tag + "\n" + other.tag.Equals("Player"));
        if (other.tag.Equals("Player"))
        {
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                Vector3 dir = (other.transform.position - transform.position).normalized;
                rb.AddForce(-dir * openForce, ForceMode.Impulse);
                ting.Play();
            }
        }
    }
}
