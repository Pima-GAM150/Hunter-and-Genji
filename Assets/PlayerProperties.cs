using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour {

    public Collection collection;

    float LifeSpan = 15.0f;

    public int KeyCount = 0;

    public Text display;

    public GameObject GunPowder;

    bool CloseToBody = false;

    bool IsBodies = false;

    GameObject body;

    GameObject[] bodies;

    GameObject CheckCloseToBody()
    {
        foreach (GameObject body in bodies)
        {
            if (Vector3.Distance(body.transform.position, gameObject.transform.position) < 2)
            {
                CloseToBody = true;
                return body;
            }
        }
        CloseToBody = false;
        return gameObject;
    }

    void Start () {
        if (collection.hasSand)
            LifeSpan += 5.0f;
        if (collection.hasKey1 && !collection.usedKey1)
            KeyCount++;
        if (collection.hasKey2 && !collection.usedKey2)
            KeyCount++;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsBodies)
            body = CheckCloseToBody();
        if (Vector3.Distance(GunPowder.transform.position, gameObject.transform.position) < 2)
            display.text = "Press 'E' to eat GunPowder";
        if (CloseToBody)
            display.text = "Press 'E' to burn body";

        if (LifeSpan <= 0)
            Destroy(gameObject);
        LifeSpan -= Time.deltaTime;
	}
}
