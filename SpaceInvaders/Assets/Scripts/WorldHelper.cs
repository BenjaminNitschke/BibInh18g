using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHelper : MonoBehaviour {

    private Camera cam;

    public Rect GetWorldDimensions()
    {
        cam = Camera.main != null ? Camera.main : Camera.allCameras[0];

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        return new Rect(-halfWidth, -halfHeight, halfWidth * 2, halfHeight * 2);
    }

    /// <summary>
    /// Used a Singleton Pattern to make the variables accessable in Unity.
    /// From: http://csharpindepth.com/articles/general/singleton.aspx
    /// and https://answers.unity.com/questions/323195/a.html
    /// </summary>
    private static WorldHelper instance;

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    private void Awake()
    {
        instance = this;
    }

    public static WorldHelper Instance
    {
        get
        {
            return instance;
        }
    }
}
