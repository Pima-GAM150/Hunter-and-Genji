using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Collection",menuName = "Collection")]
public class PlayerCollection : ScriptableObject
{
    public Collection collection = new Collection();
}
