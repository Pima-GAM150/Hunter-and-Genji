using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

    public Transform corpse;
    public Transform corpsebag;

    public Collection collection;

    float LifeSpan = 15.0f;

    public int KeyCount = 0;

    public GameObject GunPowder;

    bool CloseToBody = false;

    bool IsBodies = false;

    GameObject body;

    GameObject[] bodyBag = new GameObject[10];

    List<int> CheckCloseToBody()
    {
        CloseToBody = false;
        int pos = 0;
        List<int> bodiesToRemove = new List<int>();
        foreach (GameObject body in bodyBag)
        {
            if (Vector3.Distance(body.transform.position, gameObject.transform.position) < 2)
            {
                CloseToBody = true;
                bodiesToRemove.Add(pos);
            }
            pos++;
        }
        return bodiesToRemove;
    }

    void bodiesToRemove(List<int> bodyPos)
    {
        for (int i = 0;i < bodyBag.Length;i++)
        {

        }
    }

    void Start () {
        //Cam.transform.parent = gameObject.transform;//make the camera a child of this object
        if (collection.hasSand)
            LifeSpan += 5.0f;
        if (collection.hasKey1 && !collection.usedKey1)
            KeyCount++;
        if (collection.hasKey2 && !collection.usedKey2)
            KeyCount++;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(GunPowder.transform.position, gameObject.transform.position) < 3
            && !GetComponent<PlayerController>().willExplode())
        {
            GetComponentInChildren<Text>().text = "Press 'E' to eat GunPowder";
            GetComponent<PlayerController>().setEatEnabled(true);
        }    
        else
        {
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setEatEnabled(false);
        }

        if (LifeSpan <= 0)
        {
            if(GetComponent<PlayerController>().willExplode())
            {
                //add explosion particles
            }
            else {
                Transform corpseBody = Instantiate<Transform>(corpse);
                corpseBody.parent = corpsebag;
                corpseBody.position = transform.position;
            }

            Destroy(gameObject);
        }
            
        LifeSpan -= Time.deltaTime;
	}
}
