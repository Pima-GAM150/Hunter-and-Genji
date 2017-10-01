using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureBehavior : MonoBehaviour {

    public Animator DoorToOpen;
    public GameObject body;
    private bool switched = false;

    // Use this for initialization
    void Start () {
    }

    void onTriggerEnter(Collision e) {
        Debug.Log("Trigger");
    }
    void onCollisionEnter(Collider e) {
        Debug.Log("enter"+e.tag);
    }

    void onCollisionStay(Collider e) {
        Debug.Log("stay"+e.tag);
        if (!switched && e.tag == "Body") {
            switched = true;
            switch (DoorToOpen.tag) {//door to open
                    case "Button": DoorToOpen.SetTrigger("Sesame"); break;
                    case "Pressure": DoorToOpen.SetBool("Sesame", true); break;
                    case "Key": DoorToOpen.SetTrigger("Sesame"); break;
                    case "Flame": DoorToOpen.SetBool("Flames", false); break;
                    default: Debug.Log("Dunno what type of door this is. Set a tag"); break;
            }
        }
    }

    void onCollisionExit(Collider e) {
        if (switched) {
            switched = false;
            switch (DoorToOpen.tag) {//door to close
                case "Button": DoorToOpen.SetTrigger("Sesame"); break;
                case "Pressure": DoorToOpen.SetBool("Sesame", false); break;
                case "Key": DoorToOpen.SetTrigger("Sesame"); break;
                case "Flame": DoorToOpen.SetBool("Flames", true); break;
                default: Debug.Log("Dunno what type of door this is. Set a tag"); break;
            }
        }
    }

    void Update() {
        if (Vector3.Distance(body.transform.position, gameObject.transform.position) < 1) {
            Debug.Log("vector");
        }
    }
}
