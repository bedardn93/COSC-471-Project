using UnityEngine;
using System.Collections;

public class rifle_animation_controller : MonoBehaviour {
	Animator anim;
	int reloadHash = Animator.StringToHash("Reload");
	// Use this for initialization
	void Start () {
		//Get animator for reloading
		anim = GetComponent<Animator> ();
	}

	public void playAnimation(){
		anim.SetTrigger (reloadHash);
	}
}
