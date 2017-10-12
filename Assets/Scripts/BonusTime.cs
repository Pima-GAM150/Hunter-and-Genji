using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTime : MonoBehaviour {

    public PlayerCollection collection;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collection.hasSand = true;
            Destroy(gameObject);
        }
    }//Modifies the collection object and deletes the key
}
