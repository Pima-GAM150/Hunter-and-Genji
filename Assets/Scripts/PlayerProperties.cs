using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

    public Transform sceneBag;
    public Transform sceneWalls;
    public GameObject body;
    public BodyBag bodyBag;
    public PlayerCollection collection;
    public Wall walls;
    public GameObject cam;
    public float LifeSpan = 10.0f;
    public int KeyCount = 0;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public Transform GunPowder;

    private bool oneTimeGunPowder = true;
    private bool oneTimeDoor1 = true;
    private bool oneTimeDoor2 = true;
    private bool oneTimeDoor3 = true;
    private bool oneTimeDoor4 = true;
    private bool oneTimeDoor5 = true;

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

    List<int> CheckCloseToWall()
    {
        int pos = 0;
        List<int> wallsToRemove = new List<int>();
        foreach (Vector3 wall in walls.wallPos)
        {
            if (Vector3.Distance(wall, transform.position) < 5)
            {
                wallsToRemove.Add(pos);
            }
            else
                wallsToRemove.Add(-1);
            pos++;
        }
        return wallsToRemove;
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

    void WallsToRemove(List<int> bodyPos)
    {
        for (int i = walls.wallPos.Count - 1; i >= 0; i--)
        {
            if (bodyPos[i] == i)
            {
                walls.wallPos.RemoveAt(i);
                walls.wallRot.RemoveAt(i);
                Destroy(sceneWalls.GetChild(i).gameObject);
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
        if (collection.hasKey1)
            KeyCount++;
        if (collection.hasKey2)
            KeyCount++;
        if (collection.hasKey3)
            KeyCount++;
        if (collection.hasKey4)
            KeyCount++;
        if (collection.hasKey5)
            KeyCount++;
        if (collection.usedKey1)
            KeyCount--;
        if (collection.usedKey2)
            KeyCount--;
        if (collection.usedKey3)
            KeyCount--;
        if (collection.usedKey4)
            KeyCount--;
        if (collection.usedKey5)
            KeyCount--;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, GunPowder.position) < 3
            && !GetComponent<PlayerController>().explode)
        {
            oneTimeGunPowder = false;
            GetComponentInChildren<Text>().text = "Press 'E' to eat GunPowder";
            GetComponent<PlayerController>().setEatEnabled(true);
        }    
        else if(!oneTimeGunPowder)
        {
            oneTimeGunPowder = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setEatEnabled(false);
        }

        if (Vector3.Distance(transform.position, door1.transform.position) < 2 
            && !collection.usedKey1 && KeyCount > 0) {
            oneTimeDoor1 = false;
            GetComponentInChildren<Text>().text = "Press E to open door";
            GetComponent<PlayerController>().setDoorEnabled(true);
        }
        else if(!oneTimeDoor1){
            oneTimeDoor1 = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setDoorEnabled(false);
        }
        if (Vector3.Distance(transform.position, door2.transform.position) < 2
            && !collection.usedKey2 && KeyCount > 0)
        {
            oneTimeDoor2 = false;
            GetComponentInChildren<Text>().text = "Press E to open door";
            GetComponent<PlayerController>().setDoorEnabled(true);
        }
        else if (!oneTimeDoor2)
        {
            oneTimeDoor2 = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setDoorEnabled(false);
        }
        if (Vector3.Distance(transform.position, door3.transform.position) < 2
            && !collection.usedKey3 && KeyCount > 0)
        {
            oneTimeDoor3 = false;
            GetComponentInChildren<Text>().text = "Press E to open door";
            GetComponent<PlayerController>().setDoorEnabled(true);
        }
        else if (!oneTimeDoor3)
        {
            oneTimeDoor3 = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setDoorEnabled(false);
        }
        if (Vector3.Distance(transform.position, door4.transform.position) < 2
            && !collection.usedKey4 && KeyCount > 0)
        {
            oneTimeDoor4 = false;
            GetComponentInChildren<Text>().text = "Press E to open door";
            GetComponent<PlayerController>().setDoorEnabled(true);
        }
        else if (!oneTimeDoor4)
        {
            oneTimeDoor4 = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setDoorEnabled(false);
        }
        if (Vector3.Distance(transform.position, door5.transform.position) < 2
            && !collection.usedKey5 && KeyCount > 0)
        {
            oneTimeDoor5 = false;
            GetComponentInChildren<Text>().text = "Press E to open door";
            GetComponent<PlayerController>().setDoorEnabled(true);
        }
        else if (!oneTimeDoor5)
        {
            oneTimeDoor5 = true;
            GetComponentInChildren<Text>().text = "";
            GetComponent<PlayerController>().setDoorEnabled(false);
        }

        if (LifeSpan <= 0)
        {
            if (GetComponent<PlayerController>().willExplode())
            {
                List<int> bodiesToRemoveList = CheckCloseToBody();
                bodiesToRemove(bodiesToRemoveList);
                List<int> wallsToRemove = CheckCloseToWall();
                WallsToRemove(wallsToRemove);
            }
            else if(GetComponent<PlayerController>().burning)
            {

            }
            else {
                LeaveBody();
            }
            FindObjectOfType<SerializeToJson>().Save();
            cam.GetComponent<CamFollow>().activeCam = false;
            Destroy(gameObject);
        }
            
        LifeSpan -= Time.deltaTime;
	}
}
