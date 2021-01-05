using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teleporter : MonoBehaviour
{
    Transform teleportLink;
    private void Start()
    {
        teleportLink = transform.GetChild(0).transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided, transport to: " + teleportLink.position);
        // Only if the object is a server-side object teleport
        if (other.gameObject.GetComponent<PhotonView>()) {
            CharacterController cc = other.GetComponent<CharacterController>();

            Debug.Log("teleporting: "  + other.transform.position);
            cc.enabled = false;
            other.transform.position = teleportLink.position;
            cc.enabled = true;
        }
    }

}
