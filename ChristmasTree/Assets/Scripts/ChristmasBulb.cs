using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasBulb
{
    Material[] materials;

    public ChristmasBulb(Material[] materials)
    {
        this.materials = materials;
    }

    public Material GetRandomColor()
    {
        return materials[Random.Range(0, materials.Length - 1)];
    }
}
