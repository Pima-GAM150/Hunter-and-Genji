using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    public GameObject player;
    public Camera cam;
    private Vector3 pos = new Vector3(0, 20, 0);
    private float speed = 1.0f;
    public bool activeCam = true;

	void Start () {
        cam.GetComponent<Transform>();
	}
	
	void Update () {
        if (activeCam)cam.transform.position = player.transform.position + pos;
	}
}
