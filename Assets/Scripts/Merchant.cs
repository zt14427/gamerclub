using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Merchant : MonoBehaviour
{
    [SerializeField]
    GameObject MerchantUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name.Contains("PLAYER") && other.GetComponent<PhotonView>().IsMine)
        {
            MerchantUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Contains("PLAYER") && other.GetComponent<PhotonView>().IsMine)
        {
            exitMerchant();
        }
    }

    public void exitMerchant()
    {
        MerchantUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
