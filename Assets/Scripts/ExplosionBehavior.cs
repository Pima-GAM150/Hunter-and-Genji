using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour {

    float timer = 1.8f;
    float passedTime = 0f;

	void Update () {
        passedTime += Time.deltaTime;
        if (passedTime >= timer) Destroy(gameObject);
	}
}
