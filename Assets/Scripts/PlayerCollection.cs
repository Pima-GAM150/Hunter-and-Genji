using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Collection",menuName = "Collection")]
public class PlayerCollection : ScriptableObject
{
    public bool hasKey1 = false;
    public bool hasKey2 = false;
    public bool hasKey3 = false;
    public bool hasKey4 = false;
    public bool hasKey5 = false;
    public bool usedKey1 = false;
    public bool usedKey2 = false;
    public bool usedKey3 = false;
    public bool usedKey4 = false;
    public bool usedKey5 = false;
    public bool hasSand = false;
    public bool hasSand2 = false;
}