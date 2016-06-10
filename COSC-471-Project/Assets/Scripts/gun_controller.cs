using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gun_controller : MonoBehaviour {	
	rifle_animation_controller anim;
	AudioSource audio;
	public int damage = 10;
	public int ammo = 60;
	public int maxBullets = 30;
	public int bullets;
	float nextShot;
	public Transform bulletSpawn;
	public Transform projectile;
	public Transform bulletHole;
	public float bulletSpeed = 50.0f;
	public float nextShotTime = 0.15f;
	float nextReload;
	public float reloadTime = 2.0f;
	public Text ammoText;
	public gun_controller(){
		
	}
	// Use this for initialization
	void Start () {		
		anim = GetComponent<rifle_animation_controller> ();
		audio = GetComponent<AudioSource> ();
		//Set nextshot and nextreload timers
		nextShot = Time.fixedTime + nextShotTime;
		nextReload = Time.fixedTime;
		bullets = maxBullets;
		ammoText.text = bullets.ToString() + "/" + ammo.ToString();
	}

	// Update is called once per frame
	void Update () {
		//Draw ray for debugging purpose (scene only)

		//Shooting
		if (Input.GetKey (KeyCode.Mouse0) && canShoot()) {
			shoot ();
		}
		//Reloading
		if (Input.GetKey (KeyCode.R) && canReload()) {
			reload ();
		}
		ammoText.text = bullets.ToString() + "/" + ammo.ToString();
	}

	public void reload(){
		//Delay nextReload so player can't continue firing or initiate another reload
		nextReload = Time.fixedTime + reloadTime;
		if(anim != null)
			anim.playAnimation ();
		//If statement for handling ammo (pooled bullets) 
		//and bullet (loaded bullets) management
		if (ammo + bullets < maxBullets) {
			bullets += ammo;
			ammo = 0;
		} else{
			ammo -= maxBullets - bullets;
			bullets = maxBullets;
		}
	}

	public void shoot(){
		//Create bullet game object
		GameObject obj = Instantiate (projectile.gameObject, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		//Get rigidbody from bullet so we can apply force/move it around realistically
		Rigidbody clone = obj.GetComponent<Rigidbody> ();
		//Play shooting sound
		audio.Play ();
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;		 
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;

		if (Physics.Raycast (ray, out hit, 1000.0f)) {
			Debug.DrawLine (ray.origin, hit.point, Color.red, 15.0f);
			if (hit.collider.gameObject.tag.Equals ("Geometry")) {
				Quaternion bulletHoleRotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
				Instantiate (bulletHole, hit.point, bulletHoleRotation);
			}
			if (hit.collider.gameObject.tag.Equals ("Enemy")) {
				Debug.Log ("hit enemy");
				hit.collider.gameObject.GetComponent<enemy_health> ().takeDamage (100);
			}
		}
		//Apply force up y-axis (green axis)
		clone.AddForce (clone.transform.up * bulletSpeed);
		bullets--;
		nextShot = Time.fixedTime + nextShotTime;
	}

	//Returns true if player can shoot when next shot is available,
	//bullets is greater than 0
	//and if they aren't currently reloading
	public bool canShoot(){
		if(Time.fixedTime >= nextShot && bullets > 0 && Time.fixedTime >= nextReload)
			return true;
		return false;
	}

	//Returns true if player can reload when they have less than max mag/clip
	//has ammo to pull bullets from
	//and isn't currently reloading
	public bool canReload(){
		if(bullets < maxBullets && ammo > 0 && Time.fixedTime >= nextReload)
			return true;
		return false;
	}

    public bool outOfBullets()
    {
        if (bullets == 0)
            return true;
        return false;
    }
}
