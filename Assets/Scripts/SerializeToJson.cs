using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializeToJson : MonoBehaviour
{
    public PlayerCollection collection;
    public BodyBag bodyBag;

    public void Save()
    {
        SaveData save = new SaveData {hasKey1 = collection.hasKey1, hasKey2 = collection.hasKey2, hasKey3 = collection.hasKey3,
                                      usedKey1 = collection.usedKey1,usedKey2 = collection.usedKey2,usedKey3 = collection.usedKey3,
                                      hasSand = collection.hasSand,hasSand2 = collection.hasSand2,bodyPos = bodyBag.bodyPos.ToArray(),bodyRot = bodyBag.bodyRot.ToArray()};
        string mySavedCollection = JsonUtility.ToJson(save);      

        PlayerPrefs.SetString("save", mySavedCollection);
    }

    public void Load()
    {

        if (PlayerPrefs.HasKey("save"))
        {
            string myLoadedCollection = PlayerPrefs.GetString("save");
            SaveData loadedSave = JsonUtility.FromJson<SaveData>(myLoadedCollection);
            for (int i = loadedSave.bodyPos.Length; i < loadedSave.bodyPos.Length; i++)
            {
                bodyBag.bodyPos[i] = loadedSave.bodyPos[i];
                bodyBag.bodyRot[i] = loadedSave.bodyRot[i];
            }
            collection.hasKey1 = loadedSave.hasKey1;
            collection.hasKey2 = loadedSave.hasKey2;
            collection.hasKey3 = loadedSave.hasKey3;
            collection.usedKey1 = loadedSave.usedKey1;
            collection.usedKey2 = loadedSave.usedKey2;
            collection.usedKey3 = loadedSave.usedKey3;
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
    public bool usedKey1 = false;
    public bool usedKey2 = false;
    public bool usedKey3 = false;
    public bool hasSand = false;
    public bool hasSand2 = false;

    public Vector3[] bodyPos;
    public Quaternion[] bodyRot;
}