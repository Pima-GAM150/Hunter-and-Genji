using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour {

    public PlayerCollection collection;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            collection.hasKey2 = true;
            Destroy(gameObject);
        }
    }//Modifies the collection object and deletes the key
}
