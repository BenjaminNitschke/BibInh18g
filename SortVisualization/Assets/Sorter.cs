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
		StartCoroutine("SortAll");
	}

	private MeshRenderer[] list;
	private int iteration;
	private Material defaultMaterial;
	private Material compareMaterial;
	private Material limitMaterial;
	private Material smallestMaterial;

	private IEnumerator SortAll()
	{
		for (iteration = list.Length-1; iteration >= 0; iteration--)
		{
			var biggest = list[iteration].transform.localScale.x;
			var biggestIndex = iteration;
			for (int i = 0; i < iteration; i++)
			{
				if (list[i].transform.localScale.x > biggest)
				{
					biggest = list[i].transform.localScale.x;
					biggestIndex = i;
				}
				SetPositionAndMaterialOfAllSortedGameObjects(i, biggestIndex);
				yield return new WaitForSeconds(0.01f);
			}
			if (biggestIndex != iteration)
				Swap(list, biggestIndex, iteration);
		}
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