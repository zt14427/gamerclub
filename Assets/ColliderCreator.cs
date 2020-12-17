using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCreator : MonoBehaviour
{
    [SerializeField]
    GameObject[] props = new GameObject[7];

    void Awake()
    {
        foreach (GameObject go in props)
        {
            foreach (Transform child in go.transform)
            {
                child.gameObject.AddComponent<MeshCollider>();
            }
        }
    }
}
