using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializeToJson : MonoBehaviour
{
    public PlayerCollection collection;
    public BodyBag bodyBag;
    public Wall walls;

    public void Save()
    {
        SaveData save = new SaveData {hasKey1 = collection.hasKey1, hasKey2 = collection.hasKey2, hasKey3 = collection.hasKey3,
                                      hasKey4 = collection.hasKey4, hasKey5 = collection.hasKey5, usedKey1 = collection.usedKey1,
                                      usedKey2 = collection.usedKey2,usedKey3 = collection.usedKey3,usedKey4 = collection.usedKey4,
                                      usedKey5 = collection.usedKey5, hasSand = collection.hasSand,hasSand2 = collection.hasSand2,
                                      bodyPos = bodyBag.bodyPos.ToArray(),bodyRot = bodyBag.bodyRot.ToArray(),
                                      wallPos = walls.wallPos.ToArray(),wallRot = walls.wallRot.ToArray()};
        string mySavedCollection = JsonUtility.ToJson(save);      

        PlayerPrefs.SetString("save", mySavedCollection);
    }

    public void Load()
    {

        if (PlayerPrefs.HasKey("save"))
        {
            string myLoadedCollection = PlayerPrefs.GetString("save");
            SaveData loadedSave = JsonUtility.FromJson<SaveData>(myLoadedCollection);
            if (loadedSave.bodyPos.Length > 0)
            {
                bodyBag.bodyPos.Clear();
                bodyBag.bodyRot.Clear();
                for (int i = 0; i < loadedSave.bodyPos.Length; i++)
                {
                    bodyBag.bodyPos.Add(loadedSave.bodyPos[i]);
                    bodyBag.bodyRot.Add(loadedSave.bodyRot[i]);
                }
            }
            else
            {
                bodyBag.bodyPos.Clear();
                bodyBag.bodyRot.Clear();
            }
            if (loadedSave.wallPos.Length > 0)
            {
                walls.wallPos.Clear();
                walls.wallRot.Clear();
                for (int i = 0; i < loadedSave.wallPos.Length; i++)
                {
                    walls.wallPos.Add(loadedSave.wallPos[i]);
                    walls.wallRot.Add(loadedSave.wallRot[i]);
                }
            }
            else
            {
                walls.wallPos.Clear();
                walls.wallRot.Clear();
            }
            
            collection.hasKey1 = loadedSave.hasKey1;
            collection.hasKey2 = loadedSave.hasKey2;
            collection.hasKey3 = loadedSave.hasKey3;
            collection.hasKey4 = loadedSave.hasKey4;
            collection.hasKey5 = loadedSave.hasKey5;
            collection.usedKey1 = loadedSave.usedKey1;
            collection.usedKey2 = loadedSave.usedKey2;
            collection.usedKey3 = loadedSave.usedKey3;
            collection.usedKey4 = loadedSave.usedKey4;
            collection.usedKey5 = loadedSave.usedKey5;
            collection.hasSand = loadedSave.hasSand;
            collection.hasSand2 = loadedSave.hasSand2;
        }
    }

    public void NewGame()
    {
        SaveData newGame = new SaveData();
        string myNewGame = JsonUtility.ToJson(newGame);

        PlayerPrefs.SetString("save", myNewGame);
    }
}
[System.Serializable]
public class SaveData
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

    public Vector3[] bodyPos;
    public Quaternion[] bodyRot;

    public Vector3[] wallPos = new Vector3[] {new Vector3(18,0,5),new Vector3(18,0,8),new Vector3(18,0,11)};
    public Quaternion[] wallRot = new Quaternion[] { new Quaternion(0,0,0,0), new Quaternion(0, 0, 0, 0), new Quaternion(0, 0, 0, 0) };
}