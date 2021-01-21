using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teleporter : MonoBehaviour
{
    public int unlock = 0;
    Transform teleportLink;
    private void Start()
    {
        teleportLink = transform.GetChild(0).transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Only if the object is a server-side object teleport
        if (other.gameObject.GetComponent<PhotonView>() && LocalStats.unlockables[unlock]) {
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = teleportLink.position;
            cc.enabled = true;
        }
    }

}
