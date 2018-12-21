using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	public float TimeToChange = 0.5f;

	void Start ()
	{
		material = GetComponent<Renderer>().material;
		currentHue = Random.value;
		nextHue = Random.value;
	}

	private Material material;
	
	void Update ()
	{
		var interpolation = 1 + time / TimeToChange;
		var interpolatedHue = currentHue * (1-interpolation) + nextHue * interpolation;
		material.color = Color.HSVToRGB(interpolatedHue, 1, 1);
		Debug.Log("Interpolation: " + interpolation + ", hue: " + interpolatedHue + ", color: " +
							material.color);
		time += Time.deltaTime;
		if (time < 0)
			return;
		time -= TimeToChange;
		currentHue = nextHue;
		nextHue = Random.value;
		material.color = Color.HSVToRGB(currentHue, 1, 1);
	}

	private float time = 0;
	private float currentHue;
	private float nextHue;
}
