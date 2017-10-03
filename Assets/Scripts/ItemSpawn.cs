using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

    public PlayerCollection collection;
    public BodyBag itemBodyBag;

    public Transform sceneBag;

    public GameObject body;

    public GameObject Key1;

    //public GameObject Key2;
    //Repeat for every Key and powerUp there is

    //public GameObject Door1

    void Start()
    {
        FindObjectOfType<SerializeToJson>().Load();
        if (!collection.hasKey1)
        {
            //Instantiate(Key1, new Vector3(0f,5f,0f),new Quaternion(0f,0f,0f,0f));
            Instantiate(Key1, Key1.transform.position,Key1.transform.rotation);

        }//checks at launch if player has picked up the key, if they have it doesn't spawn it

        if(itemBodyBag.bodyPos.Count > 0)
        {
            for (int i = 0; i < itemBodyBag.bodyPos.Count; i++)
            {
                Transform corpseBody = Instantiate<Transform>(body.GetComponent<Transform>());
                corpseBody.parent = sceneBag;
                corpseBody.position = itemBodyBag.bodyPos[i];
                corpseBody.rotation = itemBodyBag.bodyRot[i];
            }
        }
        

        //if(!collection.collection.usedKey1)
            //Instantiate(Door1,Door1Pos,new Quaternion())
            //makes it so that once the player uses a key the door doesn't spawn again


        //repeat for every Key/Power Up spawn
    }
}