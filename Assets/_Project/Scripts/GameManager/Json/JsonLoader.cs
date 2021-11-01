using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public PlayerData Load(string filePath)
    {
        string dataJson = File.ReadAllText(filePath);
        return JsonUtility.FromJson<PlayerData>(dataJson);
    }
}
