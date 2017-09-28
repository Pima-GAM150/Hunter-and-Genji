using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public PlayerCollection collection;

    public GameObject Key1;
    Vector3 Key1Pos = new Vector3(-6.68f,0f,3.34f);

    //public GameObject Key2;
    //Repeat for every Key and powerUp there is

    //public GameObject Door1

    void Start()
    {
        if (!collection.collection.hasKey1)
        {
            Instantiate(Key1, Key1Pos, new Quaternion());
        }//checks at launch if player has picked up the key, if they have it doesn't spawn it

        //if(!collection.collection.usedKey1)
            //Instantiate(Door1,Door1Pos,new Quaternion())
            //makes it so that once the player uses a key the door doesn't spawn again


        //repeat for every Key/Power Up spawn
    }
}
