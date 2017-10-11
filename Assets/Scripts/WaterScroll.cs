using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScroll : MonoBehaviour {
    public Renderer water;
    private float speed = 0.02f;
    private float pos = 0f;

    void Start() {
        this.water.GetComponent<Renderer>();
    }

	void Update () {
        pos += speed;
        water.material.SetTextureOffset("_MainTex", new Vector2(0, pos));
	}
}
