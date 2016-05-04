using UnityEngine;
using System.Collections;

public class gun_controller : MonoBehaviour {
	Animator anim;
	int reloadHash = Animator.StringToHash("Reload");
	AudioSource audio;
	public int ammo = 60;
	public int maxBullets = 30;
	public int bullets;
	float nextShot;
	public Transform bulletSpawn;
	public Transform projectile;
	public float bulletSpeed = 50.0f;
	public float nextShotTime = 0.15f;
	float nextReload;
	float reloadTime = 2.0f;
	// Use this for initialization
	void Start () {
		//Get animator for reloading
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		//Set nextshot and nextreload timers
		nextShot = Time.fixedTime + nextShotTime;
		nextReload = Time.fixedTime;
		bullets = maxBullets;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Mouse0) && Time.fixedTime >= nextShot && bullets > 0 && Time.fixedTime >= nextReload) {
			//Create bullet game object
			GameObject obj = Instantiate(projectile.gameObject, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
			//Get rigidbody from bullet so we can apply force/move it around realistically
			Rigidbody clone = obj.GetComponent<Rigidbody> ();
			audio.Play ();
			//Apply force up y-axis (green axis)
			clone.AddForce (clone.transform.up * bulletSpeed);
			bullets--;
			nextShot = Time.fixedTime + nextShotTime;
		}
		//If clip has less than maxBullets then reload
		if (Input.GetKey (KeyCode.R) && bullets < maxBullets && ammo > 0 && Time.fixedTime >= nextReload) {
			//Delay nextReload so player can't continue firing or initiate another reload
			nextReload = Time.fixedTime + reloadTime;
			anim.SetBool (reloadHash, true);
			if (ammo + bullets < maxBullets) {
				bullets += ammo;
				ammo = 0;
			} else{
				ammo -= maxBullets - bullets;
				bullets = maxBullets;
			}
		}
	}
}
