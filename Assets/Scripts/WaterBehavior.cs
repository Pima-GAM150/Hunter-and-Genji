using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour {

    public BodyBag bodyBag;

	void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !OnBodyBridge())
        {
            other.GetComponent<PlayerProperties>().LifeSpan = 0;
        }
    }

    bool OnBodyBridge()
    {
        for (int i = 0;i < bodyBag.bodyPos.Count;i++)
        {
            if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, bodyBag.bodyPos[i]) < 3.5)
                return true;
        }
        return false;
    }
}
