using UnityEngine;
using System.Collections;

public class load_on_collide : MonoBehaviour {
	public int level;
	void OnTriggerEnter(Collider other){
		Debug.Log ("touched");
		if (other.tag.Equals("Player"))
			Application.LoadLevel (level);
	}
}
