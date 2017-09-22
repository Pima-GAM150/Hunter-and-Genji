using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 7;
    private Vector3 movement;
    private Vector3 lastPos;
    private bool burning = false;
    public Rigidbody player;

    void Start() {
        movement.z = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        lastPos = movement;
    }

    void Update() {
        movement.z = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        player.velocity = movement * speed;
        if (movement != lastPos) {
            player.transform.rotation = Quaternion.LookRotation(movement - lastPos);
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else {
            lastPos = movement;
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }
}
