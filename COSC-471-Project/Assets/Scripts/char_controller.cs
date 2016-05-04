using UnityEngine;
using System.Collections;

public class char_controller : MonoBehaviour {
	private float speed = 0.0f;
	public float walkSpeed = 5.0f;
	public float runSpeed = 10.0f;
	public float sprintSpeed = 16.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {				
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = sprintSpeed;
			} else if (Input.GetKey (KeyCode.LeftControl)) {
				speed = walkSpeed;
			} else {
				speed = runSpeed;
			}
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

}
