using Photon.Pun;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	private PhotonView PV;
	private CharacterController myCC;
	private Animator animator;

	[SerializeField]
	GameObject cam;

	private bool grounded = false;

	//[Header("Settings")]
	private float speed = 0f;
	private float sprintMultiplier = 1.6f;
	private float rotateSpeed = 240f;
	private Vector3 moveDirection = Vector3.zero;
	private float jumpSpeed = 26.0F;
	private float gravity = 50.0F;
	private float maxVelocity = 200f;
	private int jumpsRemaining = 1;
	private bool moving = false, falling = false;

	private void Start()
	{
		Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<CharacterController>());
		this.animator = this.GetComponent<Animator>();
		PV = GetComponent<PhotonView>();
		if (PV.IsMine)
		{
			cam.SetActive(true);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			//GetComponentInChildren<Camera>().enabled = true;
			//GetComponentInChildren<AudioListener>().enabled = true;
		}
		myCC = GetComponent<CharacterController>();
	}

    void BasicMovement()
	{
		moving = false;
		if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
		{
			Debug.Log(jumpsRemaining);
			jumpsRemaining--;
			animator.SetTrigger("Jump_t");
			moveDirection.y = jumpSpeed;
		}
		else if (myCC.isGrounded)
		{
			moveDirection.y = 0;
			jumpsRemaining = LocalStats.jumps;
		}
		else
		{
			moveDirection.y -= (moveDirection.y > -50f) ? gravity * Time.deltaTime : 0;
			falling = (moveDirection.y < -20.0f);
		}

		// diagonal fix
		if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
			&& (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
			speed /= Mathf.Sqrt(2);

		myCC.Move(moveDirection * Time.deltaTime);
		if (Input.GetKey(KeyCode.W))
		{
			myCC.Move(transform.forward * Time.deltaTime * speed);
			moving = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			myCC.Move(-transform.right * Time.deltaTime * speed);
			moving = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
			myCC.Move(-transform.forward * Time.deltaTime * speed);
			moving = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			myCC.Move(transform.right * Time.deltaTime * speed);
			moving = true;
		}
	}

	void BasicRotation()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.E))
		{
			transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}

		if (Input.GetMouseButton(1))
        {
			transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        }
	}


	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = LocalStats.runSpeed * sprintMultiplier;
		}
		else
		{
			speed = LocalStats.runSpeed;
		}
		if (PV.IsMine)
		{
			BasicMovement();
			BasicRotation();

			animator.SetBool("Falling_b", falling);

			if (moving)
			{
				animator.SetFloat("Speed_f", speed/2);
			}
			else
			{
				animator.SetFloat("Speed_f", 0);
			}
		}
	}
}
