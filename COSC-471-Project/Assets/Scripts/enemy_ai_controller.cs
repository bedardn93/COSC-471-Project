using UnityEngine;
using System.Collections;

public class enemy_ai_controller : MonoBehaviour {
	public Transform player;
	public int moveSpeed = 5;
	public int maxDist = 50;
	public int minDist = 5;
    public float shootFrequency = 30.0f;
	public float gravity = 20.0f;
	Quaternion moveRotation;
	private Vector3 moveDirection = Vector3.zero;
	private float rotY = 0.0f;
    private float shooting;
	ai_gun_controller gun;
	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<ai_gun_controller> ();
        shooting = Random.Range(0.0f, shootFrequency);
    }
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();		
		if (gun.outOfBullets () && gun.canReload ())
			gun.reload ();


        if (Vector3.Distance(transform.position, player.position) <= maxDist)
        {
            transform.LookAt(player);
            if (gun.canShoot() && Time.fixedTime >= shooting)
            {
                gun.shoot();
                shooting = Random.Range(0.0f, shootFrequency) + Time.fixedTime;
            }
        
            if (Vector3.Distance (transform.position, player.position) >= minDist) {
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * moveSpeed * Time.deltaTime);
			//rotY = Mathf.Clamp(transform.position.y, 0, 0);
			//transform.localEulerAngles = new Vector3(-rotY, transform.localEulerAngles.y, 0);
			moveDirection = transform.TransformDirection (transform.forward);			
			}
		}
	}
    
}
