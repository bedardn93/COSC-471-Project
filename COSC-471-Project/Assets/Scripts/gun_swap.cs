using UnityEngine;
using System.Collections;

public class gun_swap : MonoBehaviour
{
	public int currentWeapon;
	public GameObject[] weapons;

	void Start(){
		
	}
    
	void Update (){
		if (Input.GetKey (KeyCode.Alpha1))
			swap (0);
		if (Input.GetKey (KeyCode.Alpha2))
			swap (1);
		if (Input.GetKey (KeyCode.Alpha3))
			swap (2);
	}

	public void swap(int num) {
        currentWeapon = num;
		for (int i = 0; i < weapons.Length; i++) {
			if (i == num)
				weapons [i].gameObject.SetActive (true);
			else
				weapons [i].gameObject.SetActive (false);
		}
     }

}