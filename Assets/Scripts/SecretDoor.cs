using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    Vector3
        closePosition = new Vector3(-27.8545f, 55.27f, -100.9f),
        openPosition = new Vector3(-27.8545f, 63.67f, -100.9f);

    bool open = false;

    float speed = 10.0f;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        if (open)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closePosition, step);
        }
    }
    IEnumerator stallOpen()
    {
        open = true;
        yield return new WaitForSeconds(8);
        open = false;
    }

    public void openWall()
    {
        StartCoroutine(stallOpen());
    }
}
