using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Collect : MonoBehaviour
{
    private MeshRenderer mr;
    private SphereCollider sc;
    private Light pointLight;

    [SerializeField]
    private AudioSource gemSound;
    [SerializeField]
    private AudioSource otherSound;

    [SerializeField]
    private int gemIndex;
    [SerializeField]
    private int respawnTime;


    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
        pointLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("PLAYER"))
        {
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                gemSound.Play();
                LocalStats.gems[gemIndex]++;
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
        pointLight.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        mr.enabled = true;
        sc.enabled = true;
        pointLight.enabled = true;
    }
}
