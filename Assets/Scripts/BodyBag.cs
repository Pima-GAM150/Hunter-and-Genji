using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "bodyBag", menuName = "bodyBag")]
public class BodyBag : ScriptableObject
{
    public List<Vector3> bodyPos;
    public List<Quaternion> bodyRot;
}