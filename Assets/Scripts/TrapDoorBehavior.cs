using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorBehavior : MonoBehaviour {

    public GameObject player;
    float delay = 1.0f;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            delay = 1.0f;
    }

    void OnTriggerStay(Collider other)
    {
        if (delay <= 0.0)
        {
            player.GetComponent<PlayerProperties>().LifeSpan = 0;
        }
    }

	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
	}
}
