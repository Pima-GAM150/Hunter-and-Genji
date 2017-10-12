using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text1 : MonoBehaviour {

    public void setText(string i) {
        GetComponent<Text>().text = i;
    }
}
