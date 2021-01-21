using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TeleportNewWorld : MonoBehaviour
{
    [SerializeField]
    public int levelIndex;
    private void OnTriggerEnter(Collider other)
    {
        // Only if the object is a server-side object teleport
        if (other.gameObject.GetComponent<PhotonView>().IsMine)
        {
            PhotonNetwork.LoadLevel(levelIndex);
        }
    }
}
