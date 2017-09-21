using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeSerializer : MonoBehaviour
{

    public PlayerCollection collection;
    public PlayerProperties player;

    void Start()
    {
        player.collection = collection.collection;
    }
}
