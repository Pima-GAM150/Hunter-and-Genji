using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorBehavior : MonoBehaviour {

    public GameObject player;
    bool trigger;//check if touched
    float delay = 0.5f;//time till block falls
    private Animator anim;

    void Start() {
        anim = this.GetComponent<Animator>();
    }

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") trigger = true; 
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && delay <= 0f)//this continued to run on a body, have to check if player
        {
            player.GetComponent<PlayerProperties>().LifeSpan = 0;//kills player if standing on falling tile
        }
    }

    void Drop() {//runs animation
        anim.SetTrigger("Fallout");
    }

	void Update () {//decriment time only when triggered
        if (trigger)delay -= Time.deltaTime;
        if (delay <= 0f) Drop();
	}
}
