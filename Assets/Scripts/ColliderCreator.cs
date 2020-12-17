using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCreator : MonoBehaviour
{
    [SerializeField]
    GameObject collisionObjects;

    void Awake()
    {
        MeshRenderer[] allChildren = collisionObjects.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer m in allChildren)
        {
            if (m.gameObject.GetComponent<MeshCollider>() == null)
                m.gameObject.AddComponent<MeshCollider>();
        }
    }
}