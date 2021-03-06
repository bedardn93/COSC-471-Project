﻿using UnityEngine;
using System.Collections;

public class pistol_animation : MonoBehaviour {

    gun_controller gun;
    Animator anim;
    int reloadHash = Animator.StringToHash("Reload");
    // Use this for initialization
    void Start()
    {
        //Get animator for reloading
        anim = GetComponent<Animator>();
        gun = GetComponent<gun_controller>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.R) && gun.canReload())
        {
            anim.SetBool(reloadHash, true);
        }
        if (!gun.canReload())
            anim.SetBool(reloadHash, false);
    }
}
