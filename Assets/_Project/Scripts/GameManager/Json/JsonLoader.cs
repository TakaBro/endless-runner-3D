using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public void Load(string filePath)
    {
        Debug.Log("JSON PATH: " + filePath);
        //string dataJson = File.ReadAllText(filePath);
        //JsonUtility.FromJson<PlayerData>(dataJson);
    }
}
