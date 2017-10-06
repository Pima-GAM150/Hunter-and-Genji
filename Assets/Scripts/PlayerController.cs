using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerCollection collection;
    private float speed = 7;
    private Vector3 movement;
    private Vector3 lastPos;
    public bool burning = false;
    private bool eatEnabled = false;
    private bool explode = false;
    private bool doorEnabled = false;
    public Rigidbody player;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;

    void Start() {
        movement.z = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        lastPos = movement;
        burning = false;
        explode = false;
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    void Update() {
        movement.z = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        if (!burning) {
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
        else {//we're burning!
            player.velocity = movement + transform.forward * (speed * 1.5f);
            if (movement != lastPos) {
                player.transform.rotation = Quaternion.LookRotation(movement - lastPos);
            }
            else {
                lastPos = movement;
            }
        }
        if(eatEnabled)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                explode = true;
            }
        }
        if (doorEnabled) {
            if (Input.GetKeyDown(KeyCode.E)) {
                if (!collection.usedKey1) {
                    collection.usedKey1 = true;
                    door1.GetComponent<Door1>().OpenDoor();
                }
                if (!collection.usedKey2) {
                    collection.usedKey2 = true;
                    door2.GetComponent<Door2>().OpenDoor();
                }
                if(!collection.usedKey3) {
                    collection.usedKey3 = true;
                    door3.GetComponent<Door3>().OpenDoor();
                }
                if (!collection.usedKey4) {
                    collection.usedKey4 = true;
                    door4.GetComponent<Door4>().OpenDoor();
                }
                if (!collection.usedKey5) {
                    collection.usedKey5 = true;
                    door5.GetComponent<Door5>().OpenDoor();
                }


            }
        }
    }

    public void burn() {
        burning = true;
        GetComponent<Animator>().SetBool("Burning", true);
        GetComponentInChildren<ParticleSystem>().Play();
    }

    public bool willExplode() {
        if (explode && burning)
            return true;
        return false;
        
    }

    public void setEatEnabled(bool i) {
        eatEnabled = i;
    }

    public void setDoorEnabled(bool i) {
        doorEnabled = i;
    }
}
