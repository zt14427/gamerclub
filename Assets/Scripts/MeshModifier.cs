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


    IEnumerator buoyancyChange(Material changeTo, float duration, float buoyancy)
    {
        previousMaterial = smr.material;
        smr.material = changeTo;
        LocalStats.buoyancy = buoyancy;
        yield return new WaitForSeconds(duration);
        smr.material = previousMaterial;
        LocalStats.buoyancy = 1.0f;
    }

    public void Metalize(float duration)
    {

        float metalBuoyancy = 0.3f;

        configureCurrentSkin();
        StartCoroutine(buoyancyChange(Metal, duration, metalBuoyancy));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
