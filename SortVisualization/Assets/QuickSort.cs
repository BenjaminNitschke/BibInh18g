using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private MeshRenderer[] list;
    private int iteration;
    private Material defaultMaterial;
    private Material compareMaterial;
    private Material limitMaterial;
    private Material smallestMaterial;

    private IEnumerator coroutine;

    private void Awake()
    {
        list = FindObjectsOfType<MeshRenderer>();
        defaultMaterial = list[0].material;
        compareMaterial = Resources.Load<Material>("compareMaterial");
        limitMaterial = Resources.Load<Material>("limitMaterial");
        smallestMaterial = Resources.Load<Material>("smallestMaterial");
    }

    private void Start()
    {
        coroutine = SortQuick(list, 0, list.Length - 1);
        StartCoroutine(coroutine);
        //SortQuick(list, 0, list.Length - 1);
    }

    private IEnumerator SortQuick(MeshRenderer[] list, int low, int high)
    {
        yield return new WaitForSeconds(1f);
        if (low < high)
        {
            int p = Partition(list, low, high);
            SetPositionAndMaterialOfAllSortedGameObjects(p, low);
            StartCoroutine(SortQuick(list, low, p - 1));
            StartCoroutine(SortQuick(list, p + 1, high));
        }
    }

    private int Partition(MeshRenderer[] list, int low, int high)
    {
        float pivot = list[high].transform.localScale.x;
        int i = low;

        for(int j = low; j < high; j++)
            if(list[j].transform.localScale.x < pivot)
            {
                Swap(list, i, j);
                i++;
            }
        Swap(list, i, high);
        return i;
    }

    private void SetPositionAndMaterialOfAllSortedGameObjects(int currentIndex, int smallestIndex)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].transform.position = i * new Vector3(3, 0, 0);
            if (i == iteration)
                list[i].material = limitMaterial;
            else if (i == currentIndex)
                list[i].material = compareMaterial;
            else if (i == smallestIndex)
                list[i].material = smallestMaterial;
            else
                list[i].material = defaultMaterial;
        }
    }

    private static void Swap(MeshRenderer[] list, int first, int second)
    {
        var rememberValue = list[first];
        list[first] = list[second];
        list[second] = rememberValue;
    }
}
