using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float submergedDepth = -0.8f;
    public float displacementAmount = 3f;

    [SerializeField]
    public float buoyancy = 1f;

    [SerializeField]
    public GameObject underwaterUI;

    private Camera cam;
    private bool jumpCD = true;

    Rigidbody rb;
    CharacterMovement cm;

    // Sounds
    private AudioSource splash;

    private void Start()
    {
        splash = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (rb = other.gameObject.GetComponent<Rigidbody>())
        {
            Debug.Log("Creating force:\n" + transform.position.y + " - " + other.transform.position.y);
            float displacementMultiplier =
                Mathf.Clamp01((other.transform.position.y - transform.position.y)) * displacementAmount;
            Debug.Log("adding force: " + displacementMultiplier);
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        }

        if (cm = other.gameObject.GetComponent<CharacterMovement>())
        {
            cam = other.gameObject.GetComponentInChildren<Camera>();
            if (cm.moveDirection.y < 0f)
            {
                cm.moveDirection.y *= 0.5f;
            }
            if (cm.moveDirection.y < 0f)
            {
                splash.Play();
            }

        }

    }

    IEnumerator giveJump()
    {
        //Debug.Log("Giving a jump");
        cm.jumpsRemaining = 1;
        yield return new WaitForSeconds(1.5f);
        jumpCD = true;
    }

    private void OnTriggerExit(Collider other)
    {
        underwaterUI.SetActive(false);
        if (cm = other.gameObject.GetComponent<CharacterMovement>())
            if (!jumpCD && cm.jumpsRemaining > 0)
                cm.jumpsRemaining--;
    }

    private void OnTriggerStay(Collider other)
    {
        if (cm = other.gameObject.GetComponent<CharacterMovement>())
        {
            //Debug.Log("Player position: " + other.transform.position.y + "\nWater position: " + transform.position.y);
            //if (other.transform.position.y)
            if (other.transform.position.y - (transform.position.y + 2f) < submergedDepth)
                cm.moveDirection.y += (cm.moveDirection.y > 6) ? 0 : cm.gravity * buoyancy * Time.deltaTime * LocalStats.buoyancy;
            else
            {
                //Debug.Log("Remaining Jumps: " + cm.jumpsRemaining + ", CD: " + jumpCD);
                if (cm.jumpsRemaining == 0 && jumpCD)
                {
                    jumpCD = false;
                    StartCoroutine(giveJump());
                }
            }

            //Debug.Log(cam.transform.position.y + " : " + transform.position.y);
            if (cam.transform.position.y <= transform.position.y + 2.635f)
                underwaterUI.SetActive(true);
            else
                underwaterUI.SetActive(false);
        }
    }
}
