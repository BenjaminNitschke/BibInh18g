using System;
using System.Collections;
using UnityEngine;

// ReSharper disable once UnusedMember.Global
// ReSharper disable once CheckNamespace
public class Sorter : MonoBehaviour
{
	private void Start()
	{
		list = FindObjectsOfType<MeshRenderer>();
		defaultMaterial = list[0].material;
		compareMaterial = Resources.Load<Material>("compareMaterial");
		limitMaterial = Resources.Load<Material>("limitMaterial");
		smallestMaterial = Resources.Load<Material>("smallestMaterial");
		swapMaterial = Resources.Load<Material>("swapMaterial");
		StartCoroutine(QuickSort(0, list.Length - 1));
	}
	
	private MeshRenderer[] list;
	private Material defaultMaterial;
	private Material compareMaterial;
	private Material limitMaterial;
	private Material smallestMaterial;
	private Material swapMaterial;
	
	/// <summary>
	/// https://en.wikipedia.org/wiki/Quicksort
	/// </summary>
	private IEnumerator QuickSort(int lo, int hi)
	{
		if (lo >= hi)
			yield break;
		int p = lo;
		yield return Partition(lo, hi, result => p = result);
		yield return QuickSort(lo, p - 1);
		yield return QuickSort(p + 1, hi);
	}

	private IEnumerator Partition(int lo, int hi, Action<int> result)
	{
		// Median of three optimization
		var mid = (lo + hi) / 2;
		if (list[mid].transform.localScale.x < list[lo].transform.localScale.x)
			Swap(list, lo, mid);
		if (list[hi].transform.localScale.x < list[lo].transform.localScale.x)
			Swap(list, lo, hi);
		if (list[mid].transform.localScale.x < list[hi].transform.localScale.x)
			Swap(list, mid, hi);
		float pivot = list[hi].transform.localScale.x;
		int i = lo;
		for (int j = lo; j < hi; j++)
		{
			SetPositionAndMaterialOfAllSortedGameObjects(lo, j, hi);
			if (list[j].transform.localScale.x < pivot)
			{
				Swap(list, i, j);
				list[i].material = swapMaterial;
				i++;
			}
			yield return new WaitForSeconds(0.01f);
		}
		Swap(list, i, hi);
		SetPositionAndMaterialOfAllSortedGameObjects(lo, i, hi);
		yield return new WaitForSeconds(0.01f);
		result(i);
	}
	
	private void SetPositionAndMaterialOfAllSortedGameObjects(int lo, int currentIndex, int hi)
	{
		for (int i = 0; i < list.Length; i++)
		{
			list[i].transform.position = i * new Vector3(3, 0, 0);
			if (i == lo)
				list[i].material = limitMaterial;
			else if (i == currentIndex)
				list[i].material = compareMaterial;
			else if (i == hi)
				list[i].material = smallestMaterial;
			else
				list[i].material = defaultMaterial;
		}
	}
	
	private static void Swap<T>(T[] list, int first, int second)
	{
		var rememberValue = list[first];
		list[first] = list[second];
		list[second] = rememberValue;
	}
}