using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehavior : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void OnCollisionEnter(Collision e) {
        player.GetComponent<PlayerController>().burn();
    }
}
