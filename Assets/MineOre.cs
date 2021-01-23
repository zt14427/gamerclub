using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineOre : MonoBehaviour
{
    [SerializeField]


    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine)
        {

        }

    }

}