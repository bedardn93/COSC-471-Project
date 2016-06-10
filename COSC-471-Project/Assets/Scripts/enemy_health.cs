using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour {
	public int health = 50;
	public int pistolDamage = 15;
	public int rifleDamage = 10;
	public int rpgDamage = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			die ();
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag.Equals("PistolBullet")){
			health -= pistolDamage;
		}else if (other.gameObject.tag.Equals ("RifleBullet")) {
			health -= rifleDamage;

		}else if (other.gameObject.tag.Equals("RPGBullet")){
			health -= rpgDamage;
		}
	}

	void die(){
		Destroy (this.gameObject);
	}

	public void takeDamage(int damage){
		health -= damage;
	}
}
