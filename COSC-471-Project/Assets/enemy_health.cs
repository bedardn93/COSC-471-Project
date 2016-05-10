using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour {
	public int health = 100;
	public int takeDamage = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.Equals ("Bullet")) {
			health -= takeDamage;
			if (health <= 0)
				die ();
		}
	}

	void die(){
		Destroy (this.gameObject);
	}
}
