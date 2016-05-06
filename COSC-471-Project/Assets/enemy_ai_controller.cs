using UnityEngine;
using System.Collections;

public class enemy_ai_controller : MonoBehaviour {
	public Transform player;
	public int moveSpeed = 5;
	public int maxDist = 50;
	public int minDist = 5;
	public float gravity = 20.0f;
	Quaternion moveRotation;
	private Vector3 moveDirection = Vector3.zero;
	private float rotY = 0.0f;
	ai_gun_controller gun;
	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<ai_gun_controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		transform.LookAt (player);
		if (gun.outOfBullets () && gun.canReload ())
			gun.reload ();

		if (Vector3.Distance (transform.position, player.position) >= minDist) {
			//transform.position += transform.forward * moveSpeed * Time.deltaTime;
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
			rotY = Mathf.Clamp(transform.position.y, 0, 0);
			transform.localEulerAngles = new Vector3(-rotY, transform.localEulerAngles.y, 0);
			moveDirection = transform.TransformDirection (transform.forward);
			if (Vector3.Distance (transform.position, player.position) <= maxDist) {
				if (gun.canShoot ())
					gun.shoot ();
			}
		}
	}
}
