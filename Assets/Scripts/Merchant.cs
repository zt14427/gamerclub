using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Merchant : MonoBehaviour
{
    [SerializeField]
    GameObject MerchantUI;

    [SerializeField]
    SecretDoor door;

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

    public void purchaseBoots(GameObject item)
    {
        if (LocalStats.gems[0] >= 10)
        {
            LocalStats.gems[0] -= 10;
            LocalStats.jumps = (LocalStats.jumps == 1) ? 2 : LocalStats.jumps;
            item.SetActive(false);
        }
    }

    public void buyDoor()
    {
        if (LocalStats.gems[1] >= 1)
        {
            LocalStats.gems[1] -= 1;
            door.openWall();
        }
    }

}
