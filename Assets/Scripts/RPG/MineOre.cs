using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineOre : MonoBehaviour
{
    [SerializeField]
    string oreName = "Copper";

    [SerializeField]
    string oreColor = "brown";

    [SerializeField]
    int oreIndex = 0;

    [SerializeField]
    float respawnTime = 60;

    [SerializeField]
    Text UIAlert;

    [SerializeField]
    Material depleted, full;

    private BoxCollider bc;

    // Sounds
    AudioSource mineSound;

    private void Start()
    {
        mineSound = gameObject.GetComponent<AudioSource>();
        bc = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            UIAlert.text = "Press <F> to mine:\n<color=" + oreColor + ">" + oreName + " </color>";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            UIAlert.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.GetComponent<Photon.Pun.PhotonView>().IsMine && Input.GetKey("f"))
        {
            StartCoroutine(MineNode());
        } 
    }

    private IEnumerator MineNode()
    {
        LocalStats.ores[oreIndex]++;
        UIAlert.text = "";
        bc.enabled = false;
        for (int i = 0; i < 3; i++)
            transform.GetChild(i).GetComponent<MeshRenderer>().material = depleted;
        mineSound.Play();
        yield return new WaitForSeconds(respawnTime);

        bc.enabled = true;
        for (int i = 0; i < 3; i++)
            transform.GetChild(i).GetComponent<MeshRenderer>().material = full;
    }
}