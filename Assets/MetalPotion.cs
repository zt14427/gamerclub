using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MetalPotion : MonoBehaviour
{
    [SerializeField]
    private int duration;
    [SerializeField]
    private int respawnTime;

    private MeshModifier mm;

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
            Debug.Log("metallizing");
            if (mm = other.gameObject.GetComponent<MeshModifier>())
            {
                mm.Metalize(duration);
                StartCoroutine(respawnPotion());
            }
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
