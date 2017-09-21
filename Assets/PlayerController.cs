using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 7;
    private Vector3 movement;
    public Rigidbody player;

    void Start() {
    }

    void Update() {
        movement.z = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        player.velocity = movement * speed;
    }
}
