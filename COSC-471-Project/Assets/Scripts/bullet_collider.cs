using UnityEngine;
using System.Collections;

public class bullet_collider : MonoBehaviour {
	public Transform hitPrefab;

	void OnCollisionEnter(){
		GameObject hitEmitter = Instantiate (hitPrefab, transform.position, transform.rotation) as GameObject;
		Destroy (this.gameObject);

	}
}
