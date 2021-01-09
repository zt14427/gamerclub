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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered: " + other.transform.name);
        if (other.transform.name.Contains("PLAYER"))
        {
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                Vector3 dir = (other.transform.position - transform.position).normalized;
                rb.AddForce(-dir * openForce, ForceMode.Impulse);
            }
        }
    }
}
