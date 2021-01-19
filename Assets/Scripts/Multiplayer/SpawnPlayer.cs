using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public New_Camera cam;
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Vector3 spawnLocation = transform.position;
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PLAYER"), spawnLocation, Quaternion.identity);
        LocalStats.Player = player;
        Debug.Log("LocalStats set");
    }

}
