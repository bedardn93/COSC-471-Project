using UnityEngine;
using System.Collections;

public class destroy_timer : MonoBehaviour {
	public float deathTimer = 1.0f;

	void FixedUpdate () {
		Destroy (this.gameObject, deathTimer);
	}
}
