using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text UIAlert;

    [SerializeField]
    Material activatedMaterial;

    [System.NonSerialized]
    public static Checkpoint previousCheckpoint;
    [System.NonSerialized]
    public MeshRenderer mr;
    [System.NonSerialized]
    public Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        originalMaterial = mr.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Photon.Pun.PhotonView>().IsMine  && previousCheckpoint != this)
        {
            UIAlert.text = "Press <F> to set Checkpoint";
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
            UIAlert.text = "";
            setCheckpoint();
        }
    }

    public void setCheckpoint()
    {
        if (previousCheckpoint)
            previousCheckpoint.mr.material = previousCheckpoint.originalMaterial;
        mr.material = activatedMaterial;
        Respawn.RespawnLocation.position = transform.position + new Vector3(0f, 2f, 0f);
        previousCheckpoint = this;
    }
}
