using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "bodyBag", menuName = "bodyBag")]
public class BodyBag : ScriptableObject
{
    public List<Transform> bodyBag = new List<Transform>();
}
