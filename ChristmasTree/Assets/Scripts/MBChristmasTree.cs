using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBChristmasTree : MonoBehaviour
{
    public GameObject prefab;

    private ChristmasTree tree;
    private GameObject view;

    public void Start()
    {
        view = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Tree created");
    }

    void Update ()
    {
		
	}
}
