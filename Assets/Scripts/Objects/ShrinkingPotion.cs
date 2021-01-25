using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShrinkingPotion : MonoBehaviour
{
    [SerializeField]
    private int duration;
    [SerializeField]
    private int respawnTime;

    private MeshRenderer mr;
    private SphereCollider sc;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Potion collided with: " + other.transform.name);
        if (other.tag.Equals("Player"))
        {
            Debug.Log("shrinking");
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                LocalStats.scale = 0.5f;
                LocalStats.scaleDuration = duration;
                StatusEffectUI.AddEffect("Shrunk", duration, "purple");
                LocalStats.Scale();
            }
            StartCoroutine(respawnPotion());
        }
    }

    IEnumerator respawnPotion()
    {
        mr.enabled = false;
        sc.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        mr.enabled = true;
        sc.enabled = true;
    }
}
