using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickColor : MonoBehaviour, IPointerClickHandler {
	private ColorManager colorManager;

	// Use this for initialization
	void Start ()
	{
		colorManager = GameObject.Find("Shield").GetComponent<ColorManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		colorManager.SetNextColor(GetComponent<Image>().color);
	}
}
