using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private const float MIN_Y_ANGLE = -13.0f, MAX_Y_ANGLE = 89f;
    
    public Transform playerTransform;   // player gameObject transform.
    Vector3 thirdPersonOffset;          // vector offset above player gameObject.
    private Transform Obstruction;
    float zoomSpeed = 2.0f;

    public float distance = 12.0f;
    private float mouseX = 0.0f;        // Current X value of mouse input.
    private float mouseY = 0.0f;        // Current Y value of mouse input.
    private float initialCameraAngle;   // Inital angle of the player's camera.
    public float height = 1.0f;
    private void Start()
    {
        thirdPersonOffset = new Vector3(playerTransform.position.x, playerTransform.position.y + height, playerTransform.position.z);
        transform.LookAt(thirdPersonOffset); // Face Camera towards thirdPersonOffset.

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;       // Cursor is centered to the screen and locked in place.
        initialCameraAngle = transform.eulerAngles.x;   // Initial angle between interpolation vector and thirdPersonOffset.
    }
    private void Update()
    {
        mouseInput(); 
    }
    private void LateUpdate()
    {
        thirdPersonOffset = new Vector3(playerTransform.position.x, playerTransform.position.y + height, playerTransform.position.z);
        repositionCamera();
    }

    void mouseInput()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, MIN_Y_ANGLE, MAX_Y_ANGLE);
    }

    void repositionCamera()
    {
        Vector3 dist = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = thirdPersonOffset + (rotation * dist);
        transform.LookAt(thirdPersonOffset);

        if (Input.GetMouseButton(1))
        {
            playerTransform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    /*
    void ViewObstruction()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, playerTransform.position) >= 1.5f)
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, playerTransform.position) < 4.5f)
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }
    */
}
