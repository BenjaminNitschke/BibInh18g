using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {
	private GameObject[] picks;
	private GameObject[] pins;

	// Use this for initialization
	void Start ()
	{
		picks = new[]
		{
			GameObject.Find("Pick1Position"), GameObject.Find("Pick1Position"),
			GameObject.Find("Pick1Position"), GameObject.Find("Pick1Position")
		};
		pins = new[]
		{
			GameObject.Find("Pin1Position"), GameObject.Find("Pin1Position"),
			GameObject.Find("Pin1Position"), GameObject.Find("Pin1Position")
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNextColor(Color color)
	{
		//Todo: number
		var image = picks[0].GetComponent<Image>();
		image.enabled = true;
		image.color = color;
	}
}
