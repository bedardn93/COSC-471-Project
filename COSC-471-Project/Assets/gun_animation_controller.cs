using UnityEngine;
using System.Collections;

public class gun_animation_controller : MonoBehaviour {
	Animator anim;
	int reloadHash = Animator.StringToHash("Reload");
	float nextReload;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		nextReload = Time.fixedTime;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) && Time.fixedTime >= nextReload) {
			Debug.Log ("Reloading");
			anim.SetBool (reloadHash, true);
			nextReload = Time.fixedTime + 2.0f;
		}
	}
}
