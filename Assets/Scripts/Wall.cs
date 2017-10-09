using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Wall", menuName = "Wall")]
public class Wall : ScriptableObject
{
    public List<Vector3> wallPos = new List<Vector3> { new Vector3(18, 0, 5), new Vector3(18, 0, 8), new Vector3(18, 0, 11) };
    public List<Quaternion> wallRot = new List<Quaternion> { new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0) };
}