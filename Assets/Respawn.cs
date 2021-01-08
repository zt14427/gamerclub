using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    Transform RespawnLocation;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("PLAYER"))
        {
            CharacterController cc = other.transform.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = RespawnLocation.position;
            cc.enabled = true;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
