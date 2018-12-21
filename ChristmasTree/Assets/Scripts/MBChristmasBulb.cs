using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBChristmasBulb : MonoBehaviour
{
    public GameObject prefab;

    public Material[] materials;

    private List<ChristmasBulb> bulbs;
    private List<GameObject> views;

    public void Start()
    {
    }

    private void CreateBulbs(int[] amountPerLayer)
    {
        for (int layer = 0; layer < amountPerLayer.Length; layer++)
        {
            for (int i = 0; i < amountPerLayer[layer]; i++)
            {

            }
        }
    }
}
