using UnityEngine;
using System.Collections;

public class gun_controller : MonoBehaviour {
	Canvas canvas;
	GUIText text;
	public int maxBullets = 30;
	public int bullets = 30;
	float nextShotTime;

	// Use this for initialization
	void Start () {
		nextShotTime = Time.fixedTime + 0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Mouse0) && Time.fixedTime >= nextShotTime && bullets > 0) {
			bullets--;
			nextShotTime = Time.fixedTime + 0.1f;
		}
		if (Input.GetKey (KeyCode.R) && bullets < 30) {
			bullets = maxBullets;
		}
	}
}
