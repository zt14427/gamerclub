using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Collect : MonoBehaviour
{
    private MeshRenderer mr;
    private SphereCollider sc;

    [SerializeField]
    private AudioSource gemSound;
    [SerializeField]
    private AudioSource otherSound;


    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("PLAYER"))
        {
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                gemSound.Play();
                LocalStats.gems[0]++;
            } else
            {
                otherSound.Play();
            }
            StartCoroutine(PauseGem());
        }
    }
    IEnumerator PauseGem()
    {
        mr.enabled = false;
        sc.enabled = false;
        yield return new WaitForSeconds(60);
        mr.enabled = true;
        sc.enabled = true;
    }
}
