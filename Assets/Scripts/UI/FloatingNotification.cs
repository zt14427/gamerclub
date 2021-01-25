using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class FloatingNotification : MonoBehaviour
{
    private float lifetime = 3;

    public static void float_notify(string message, Vector3 position) {
        GameObject text = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Floating Text"),
            position, Quaternion.identity);
        text.GetComponent<TextMesh>().text = message;
    }
}
