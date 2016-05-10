using UnityEngine;
using System.Collections;

public class load_on_click : MonoBehaviour {

	void Start(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	public void LoadScene(int level){
		Application.LoadLevel (level);
	}
}
