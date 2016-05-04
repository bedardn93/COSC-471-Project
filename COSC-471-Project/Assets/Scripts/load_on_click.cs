using UnityEngine;
using System.Collections;

public class load_on_click : MonoBehaviour {

	public void LoadScene(int level){
		Application.LoadLevel (level);
	}
}
