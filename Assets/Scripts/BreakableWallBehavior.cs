using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallBehavior : MonoBehaviour {

    public GameObject player;

    public bool CloseToWall()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 5)
            return true;
        return false;
    }

    public void DestroyWall()
    {
        Destroy(gameObject);
    }
}
