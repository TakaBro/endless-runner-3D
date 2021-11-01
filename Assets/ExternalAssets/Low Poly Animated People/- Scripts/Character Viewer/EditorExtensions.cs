﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using System.Reflection;

public static class EditorExtensions {

	public static void SaveTexture(Sprite sprite, string path, string name)
    {
        byte[] bytes = sprite.texture.EncodeToPNG();
        File.WriteAllBytes(path + "/" + name + ".png", bytes);
    }

    [ContextMenu("Get Path")]
    public static string GetPath()
    {
        /*Type projectWindowUtilType = typeof(ProjectWindowUtil);
        MethodInfo getActiveFolderPath = projectWindowUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
        object obj = getActiveFolderPath.Invoke(null, new object[0]);
        return obj.ToString();*/
        return "test";
    }
}
