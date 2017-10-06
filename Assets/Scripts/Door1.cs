using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door1 : MonoBehaviour {

    public Animator door;
    public PlayerCollection collection;

    public void OpenDoor() {
        door.SetTrigger("Sesame");
    }
}
