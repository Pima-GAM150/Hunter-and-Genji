using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

    public Transform sceneBag;
    public GameObject body;
    public BodyBag bodyBag;
    public Collection collection;

    float LifeSpan = 5.0f;

    public int KeyCount = 0;

    public GameObject GunPowder;

    bool CloseToBody = false;

    List<int> CheckCloseToBody()
    {
        CloseToBody = false;
        int pos = 0;
        List<int> bodiesToRemove = new List<int>();
        foreach (Transform body in bodyBag.bodyBag)
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
        for(int i = bodyBag.bodyBag.Count; i >= 0; i--)
        {
            if(bodyPos[i] == i)
            {
                bodyBag.bodyBag.RemoveAt(i);
            }
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
                Transform corpseBody = Instantiate<Transform>(body.GetComponent<Transform>());//instantiate body prefab                
                corpseBody.parent = sceneBag;//make it a child in the Scene BodyBog
                corpseBody.position = new Vector3(transform.position.x, 0f, transform.position.z);//issues with the Y position, so zeroed it out. //move to player position
                corpseBody.rotation = transform.rotation;//move to player rotation
                
                //bodyBag.bodyBag.Add(transform);//serialization of bodies
                //bodyBag.bodyBag.Add(corpseBody);
            }

            Destroy(gameObject);
        }
            
        LifeSpan -= Time.deltaTime;
	}
}
