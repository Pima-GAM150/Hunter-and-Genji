using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    public Animator DoorToOpen;
    public float Timer = 7;
    private float TimerDefault;
    private bool switched = false;

	// Use this for initialization
	void Start () {
        TimerDefault = Timer;//save the specific time on this object
	}
	
	// Update is called once per frame
	void Update () {
        if (switched) Timer -= Time.deltaTime;
        if (Timer <= 0) {
            //Debug.Log("Resetting");
            Timer = TimerDefault;//reset to the preset value
            switched = false;
            GetComponent<Animator>().SetBool("Reset",true);
            if (DoorToOpen.tag == "Pressure") DoorToOpen.SetBool("Sesame", false);
            else if (DoorToOpen.tag == "Flame") DoorToOpen.SetBool("Flames", true);
        }
	}

    //void OnCollisionEnter(Collision e) {
    void OnTriggerEnter(Collider e) { 
        if (!switched) {//prolly no need to check this because there were no issues
            GetComponent<Animator>().SetBool("Reset", false);//make sure the animation will stop
            //Debug.Log("Squished");
            GetComponent<Animator>().SetTrigger("Squishy");
            switched = true;
            switch (DoorToOpen.tag) {
                case "Button":DoorToOpen.SetTrigger("Sesame");break;
                case "Pressure":DoorToOpen.SetBool("Sesame", true);break;
                case "Key":DoorToOpen.SetTrigger("Sesame");break;
                case "Flame":DoorToOpen.SetBool("Flames", false);break;
                default:Debug.Log("Dunno what type of door this is. Set a tag");break;
            }


        }
    }
}
