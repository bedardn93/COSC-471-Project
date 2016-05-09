using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class player_health_controller : MonoBehaviour {
	public int health = 100;
	public int takeDamage = 10;
	bool gameOver = false;
	private GameObject player;
	private gun_swap gun;
	public Text healthText;
	public Text gameOverText;
	//public GUIText

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		gun = GetComponent<gun_swap> ();
		gameOverText.enabled = false;
		if (healthText == null)
			Debug.Log (healthText.text);
		healthText.text = "Health: " + health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true) {
			Time.timeScale = 0.0f;
			if (Input.GetKey (KeyCode.Space))
				restartCurrentScene();
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.Equals ("EnemyBullet")) {
			health -= takeDamage;
			if (health <= 0)
				die ();
			healthText.text = "Health: " + health.ToString();
		}
	}

	void restartCurrentScene(){
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}

	void die(){
		gun.swap(-1);
		gun.enabled = false;
		health = 0;
		gameOverText.enabled = true;
		gameOver = true;
	}
}
