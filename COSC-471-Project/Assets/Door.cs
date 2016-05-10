using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    Animator animator;
    bool DoorOpen;

    void Start()
    {
        DoorOpen = false;
        animator = GetComponent<Animator>();
    }

    void Enter(Collider ent)
    {
        if (ent.gameObject.tag == "Player")
        {
            DoorOpen = true;
            DoorTrigger("Open");
        }
    }

    void Exit (Collider ent)
    {
        if (DoorOpen)
        {
            DoorOpen = false;
            DoorTrigger("Close");
        }
    }

    void DoorTrigger(string direct)
    {
        animator.SetTrigger(direct);
    }
}
