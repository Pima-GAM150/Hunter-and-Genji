﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door5 : MonoBehaviour {

    public Animator door;
    public PlayerCollection collection;

    public void OpenDoor() {
        door.SetTrigger("Sesame");
    }
}