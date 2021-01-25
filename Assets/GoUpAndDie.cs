using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpAndDie : MonoBehaviour
{
    [SerializeField]
    float lifetime = 3;

    float instantiateTime;

    private void Start()
    {
        instantiateTime = Time.time;
        transform.LookAt(LocalStats.Player.transform.position);
        transform.Rotate(0f, 180f, 0f);
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    void Update()
    {
        // Move the object upward in world space 1 unit/second.
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (Time.time > (instantiateTime + lifetime))
            Destroy(this.gameObject);
    }
}
