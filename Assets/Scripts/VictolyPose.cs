using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictolyPose : MonoBehaviour {

    public Animator player;
    public Animator cam;
    public GameObject Pcontrol;
    public GameObject Ptimer;

    void Start() {

    }

    void OnCollisionEnter(Collision e) {
        Pcontrol.GetComponent<PlayerController>().TriggerWinCondition();//disables player movement and timer
        Ptimer.GetComponent<PlayerProperties>().LifeSpan = 66f;//increase lifespan to be able to watch the victory pose
        player.SetTrigger("Victoly");
        cam.SetTrigger("Victoly");
    }
}
