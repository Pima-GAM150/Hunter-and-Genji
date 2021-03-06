﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public PlayerCollection collection;
    public BodyBag itemBodyBag;
    public Wall walls;

    public Transform sceneWalls;
    public Transform sceneBag;

    public GameObject wall;
    public GameObject body;

    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject Key4;
    public GameObject Key5;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;

    public GameObject clock;

    //public GameObject Key2;
    //Repeat for every Key and powerUp there is

    //public GameObject Door1

    public void ResetAll() {
        //used for testing, also how we're going to reset the game if the player wants
        FindObjectOfType<SerializeToJson>().NewGame();
    }

    void Start()
    {
        FindObjectOfType<SerializeToJson>().Load();
        if (!collection.hasKey1)
        {
            //Instantiate(Key1, new Vector3(0f,5f,0f),new Quaternion(0f,0f,0f,0f));
            Instantiate(Key1, Key1.transform.position,Key1.transform.rotation);

        }//checks at launch if player has picked up the key, if they have it doesn't spawn it
        if (!collection.hasKey2) {
            Instantiate(Key2, Key2.transform.position, Key2.transform.rotation);
        }
        if (!collection.hasKey3) {
            Instantiate(Key3, Key3.transform.position, Key3.transform.rotation);
        }
        if (!collection.hasKey4) {
            Instantiate(Key4, Key4.transform.position, Key4.transform.rotation);
        }
        if (!collection.hasKey5) {
            Instantiate(Key5, Key5.transform.position, Key5.transform.rotation);
        }
        if (collection.usedKey1) {
            door1.GetComponent<Door1>().OpenDoor();
        }
        if (collection.usedKey2) {
            door2.GetComponent<Door2>().OpenDoor();
        }
        if (collection.usedKey3) {
            door3.GetComponent<Door3>().OpenDoor();
        }
        if (collection.usedKey4) {
            door4.GetComponent<Door4>().OpenDoor();
        }
        if (collection.usedKey5) {
            door5.GetComponent<Door5>().OpenDoor();
        }
        if (!collection.hasSand) {
            Instantiate(clock, clock.transform.position, clock.transform.rotation);
        }

        if (itemBodyBag.bodyPos.Count > 0)
        {
            for (int i = 0; i < itemBodyBag.bodyPos.Count; i++)
            {
                Transform corpseBody = Instantiate<Transform>(body.GetComponent<Transform>());
                corpseBody.parent = sceneBag;
                corpseBody.position = itemBodyBag.bodyPos[i];
                corpseBody.rotation = itemBodyBag.bodyRot[i];
            }
        }

        if (walls.wallPos.Count > 0)
        {
            for (int i = 0; i < walls.wallPos.Count;i++)
            {
                Transform spawnWall = Instantiate<Transform>(wall.GetComponent<Transform>());
                spawnWall.parent = sceneWalls;
                spawnWall.position = walls.wallPos[i];
                spawnWall.rotation = walls.wallRot[i];
            }
        }
        

        //if(!collection.collection.usedKey1)
            //Instantiate(Door1,Door1Pos,new Quaternion())
            //makes it so that once the player uses a key the door doesn't spawn again


        //repeat for every Key/Power Up spawn
    }
}