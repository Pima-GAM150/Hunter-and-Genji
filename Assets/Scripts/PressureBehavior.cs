using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureBehavior : MonoBehaviour {

    public Animator DoorToOpen;
    public Animator DoorToClose;
    public GameObject body;
    private bool switched = false;

    // Use this for initialization
    void Start () {
        OpenSesame(DoorToClose);
    }

    void OnCollisionStay(Collision e) {
        if (!switched && e.collider.tag == "Body") {
            switched = true;
            OpenSesame(DoorToOpen);
            Closesame(DoorToClose);
        }
    }

    void OnCollisionExit(Collision e) {
        if (switched) {
            switched = false;
            Closesame(DoorToOpen);
            OpenSesame(DoorToClose);
        }
    }

    void OpenSesame(Animator Door) {
        switch (Door.tag) {//door to open
            case "Button": Door.SetTrigger("Sesame"); break;
            case "Pressure": Door.SetBool("Sesame", true); break;
            case "Key": Door.SetTrigger("Sesame"); break;
            case "Flame": Door.SetBool("Flames", false); break;
            default: Debug.Log("Dunno what type of door this is. Set a tag"); break;
        }
    }

    void Closesame(Animator Door) {
        switch (Door.tag) {//door to close
            case "Button": Door.SetTrigger("Sesame"); break;
            case "Pressure": Door.SetBool("Sesame", false); break;
            case "Key": Door.SetTrigger("Sesame"); break;
            case "Flame": Door.SetBool("Flames", true); break;
            default: Debug.Log("Dunno what type of door this is. Set a tag"); break;
        }
    }

    void Update() {
        if (Vector3.Distance(body.transform.position, gameObject.transform.position) < 1) {
            Debug.Log("vector");
        }
    }
}
