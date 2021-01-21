using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshModifier : MonoBehaviour
{
    GameObject activeSkin;
    Material previousMaterial;

    [SerializeField]
    public Material Metal;

    SkinnedMeshRenderer smr;

    private void configureCurrentSkin()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("SC") && child.gameObject.activeSelf)
            {
                activeSkin = child.gameObject;
                smr = activeSkin.GetComponent<SkinnedMeshRenderer>();
            }
        }
    }

    void Start()
    {
        configureCurrentSkin();
    }

    IEnumerator changeMaterial(Material changeTo, float duration)
    {
        previousMaterial = smr.material;
        smr.material = changeTo;
        yield return new WaitForSeconds(duration);
        smr.material = previousMaterial;

    }

    public void Metalize(float duration)
    {
        configureCurrentSkin();
        StartCoroutine(changeMaterial(Metal, duration));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
