using System.Linq;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    private Material defaultMaterial, compareMaterial, limitMaterial;

	void Start()
	{
		list = GameObject.FindObjectsOfType<MeshRenderer>();
        defaultMaterial = list[0].material;
        compareMaterial = Resources.Load<Material>("Materials/Compare");
        limitMaterial = Resources.Load<Material>("Materials/Limit");
    }

	private MeshRenderer[] list;
	private int iteration = 0;
	private float timePassed = 0;

	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			timePassed -= 1;
			if (iteration < list.Length - 1)
			{
				var smallestIndex = FindSmallestIndex(list, iteration);
				Swap(list, smallestIndex, iteration);
				SetPositionAndMaterialOfAllSortedGameObjects(list);
			}
			iteration++;
		}
	}
	
	private void SetPositionAndMaterialOfAllSortedGameObjects(MeshRenderer[] list)
	{
		for (int i = 0; i < list.Length; i++)
        {
            list[i].transform.position = i * new Vector3(3, 0, 0);
            list[i].material = i == iteration ? compareMaterial : i == iteration + 1 ? limitMaterial : defaultMaterial;
        }
			
	}

	private int FindSmallestIndex(MeshRenderer[] list, int iteration)
	{
		var smallest = list[iteration].transform.localScale.x;
		var smallestIndex = iteration;
		for (int i=iteration+1; i<list.Length; i++)
			if (list[i].transform.localScale.x < smallest)
			{
				smallest = list[i].transform.localScale.x;
				smallestIndex = i;
			}
		return smallestIndex;
	}

	private void Swap(MeshRenderer[] list, int first, int second)
	{
		var rememberValue = list[first];
		list[first] = list[second];
		list[second] = rememberValue;
	}
}