﻿using UnityEngine;
using System.Collections;

public class ai_gun_controller : MonoBehaviour {
	AudioSource audio;
	public int ammo = 60;
	public int maxBullets = 30;
	private int bullets;
	float nextShot;
	public Transform bulletSpawn;
	public Transform projectile;
	public Transform bulletHole;
	public float bulletSpeed = 50.0f;
	public float nextShotTime = 0.15f;
	float nextReload;
	public float reloadTime = 2.0f;
	Animator anim;
	int reloadHash = Animator.StringToHash("Reload");
	public ai_gun_controller(){

	}

	void Start(){
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		bullets = 30;
	}
	public void reload(){
		anim.SetBool (reloadHash, true);
		//Delay nextReload so player can't continue firing or initiate another reload
		nextReload = Time.fixedTime + reloadTime;
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
		if (Physics.Raycast (ray, out hit, 1000.0f)) {
			if (hit.collider.gameObject.tag.Equals ("Geometry")) {
				Quaternion bulletHoleRotation = Quaternion.FromToRotation (Vector3.up, hit.normal);
				Instantiate (bulletHole, hit.point, bulletHoleRotation);
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

	public bool outOfBullets(){
		if (bullets == 0)
			return true;
		return false;
	}
}
