using Photon.Pun;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	private PhotonView PV;
	private CharacterController myCC;


	private bool grounded = false;

	//[Header("Settings")]
	private float speed = 0f;
	private float moveSpeed = 10f;
	private float sprintSpeed = 19f;
	private float rotateSpeed = 240f;
	private Vector3 moveDirection = Vector3.zero;
	private float jumpSpeed = 26.0F;
	private float gravity = 50.0F;
	private float maxVelocity = 200f;
	//public var velocidade = 30;

	Vector3 syncPos = Vector3.zero;
	Quaternion syncRot = Quaternion.identity;

	private void Start()
	{
		Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<CharacterController>());
		PV = GetComponent<PhotonView>();
		if (PV.IsMine)
		{
			GetComponentInChildren<Camera>().enabled = true;
			GetComponentInChildren<AudioListener>().enabled = true;
		}
		myCC = GetComponent<CharacterController>();
	}

    void BasicMovement()
	{
		if (myCC.isGrounded && Input.GetButton("Jump"))
		{
			moveDirection.y = jumpSpeed;
		}
		if (myCC.isGrounded && moveDirection.y < 0)
		{
			moveDirection.y = 0;
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}

		// diagonal fix
		if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
			&& (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
			speed /= Mathf.Sqrt(2);

		myCC.Move(moveDirection * Time.deltaTime);
		if (Input.GetKey(KeyCode.W))
		{
			myCC.Move(transform.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			myCC.Move(-transform.right * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			myCC.Move(-transform.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			myCC.Move(transform.right * Time.deltaTime * speed);
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
	}


	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = sprintSpeed;
		}
		else
		{
			speed = moveSpeed;
		}
		if (PV.IsMine)
		{
			BasicMovement();
			BasicRotation();
		}
	}
}
