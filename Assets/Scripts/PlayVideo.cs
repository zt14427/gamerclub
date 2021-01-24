using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Video.VideoPlayer video;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            video.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            video.Stop();
        }
    }
}
