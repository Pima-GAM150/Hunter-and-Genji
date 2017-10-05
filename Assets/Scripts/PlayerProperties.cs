using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

    public Transform sceneBag;
    public GameObject body;
    public BodyBag bodyBag;
    public PlayerCollection collection;
    public GameObject breakableWall;

    public float LifeSpan = 10.0f;
    public int KeyCount = 0;

    public GameObject GunPowder;

    List<int> CheckCloseToBody()
    {
        int pos = 0;
        List<int> bodiesToRemove = new List<int>();
        foreach (Vector3 body in bodyBag.bodyPos)
        {
            if (Vector3.Distance(body, transform.position) < 7.5)
            {
                bodiesToRemove.Add(pos);
            }
            else
                bodiesToRemove.Add(-1);
            pos++;
        }
        return bodiesToRemove;
    }

    void bodiesToRemove(List<int> bodyPos)
    {
        for(int i = bodyBag.bodyPos.Count - 1; i >= 0; i--)
        {
            if(bodyPos[i] == i)
            {
                bodyBag.bodyPos.RemoveAt(i);
                bodyBag.bodyRot.RemoveAt(i);
                Destroy(sceneBag.GetChild(i).gameObject);
            }
        }
    }

    void LeaveBody()
    {
        Transform corpseBody = Instantiate<Transform>(body.GetComponent<Transform>());//instantiate body prefab                
        corpseBody.parent = sceneBag;//make it a child in the Scene BodyBog
        corpseBody.position = new Vector3(transform.position.x, 1.4f, transform.position.z);//issues with the Y position, so zeroed it out. //move to player position
        corpseBody.rotation = transform.rotation;//move to player rotation

        bodyBag.bodyPos.Add(corpseBody.position);
        bodyBag.bodyRot.Add(corpseBody.rotation);
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
        if (Vector3.Distance(GunPowder.transform.position, transform.position) < 3
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
            if (GetComponent<PlayerController>().willExplode())
            {
                List<int> bodiesToRemoveList = CheckCloseToBody();
                bodiesToRemove(bodiesToRemoveList);
                if (breakableWall.GetComponent<BreakableWallBehavior>().CloseToWall())
                    breakableWall.GetComponent<BreakableWallBehavior>().DestroyWall();
            }
            else if(GetComponent<PlayerController>().burning)
            {

            }
            else {
                LeaveBody();
            }
            FindObjectOfType<SerializeToJson>().Save();
            Destroy(gameObject);
        }
            
        LifeSpan -= Time.deltaTime;
	}
}
