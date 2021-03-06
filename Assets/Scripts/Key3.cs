﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour {

    public PlayerCollection collection;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collection.hasKey3 = true;
            FindObjectOfType<PlayerProperties>().getKeyCount();
            Destroy(gameObject);
        }
    }//Modifies the collection object and deletes the key
}
