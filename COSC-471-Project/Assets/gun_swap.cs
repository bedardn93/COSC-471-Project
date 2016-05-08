using UnityEngine;
using System.Collections;

public class gun_swap : MonoBehaviour
{
    public int guns;
    public transform[] guns;
    
    function input(){
        if(Input.GetButtonDown(KeyCode.Alpha1))
            swap(1);
        if(Input.GetButtonDown(KeyCode.Alpha2))
            swap(2);
        if(Input.GetButtonDown(KeyCode.Alpha3))
            swap(3);

        public void swap(int num) {
            currentWeapon = num;
            for(int i = 0; i < weapons.Length; i++) {
                if(i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
     }

}