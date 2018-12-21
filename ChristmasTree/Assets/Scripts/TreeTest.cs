using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTest : MonoBehaviour {

    public float timeToChange = 0.5f;
    private float time;
    
    private Material material;

    private float currentHue;
    private float nextHue;

	// Use this for initialization
	void Start ()
    {
        material = GetComponent<Renderer>().material;

        currentHue = Random.value;
        nextHue = Random.value;

        timeToChange = 3f;
}
	
	// Update is called once per frame
	void Update ()
    {
        float deltaTime = Time.deltaTime;

        float interpolation = 1 + time / timeToChange;

        //float hueValue = currentHue * (1 - interpolation) + nextHue * interpolation;
        float hueValue = Mathf.Lerp(currentHue, nextHue, interpolation);

        material.color = Color.HSVToRGB(hueValue, 1, 1);

        time += deltaTime;

        if (time < 0)
            return;

        time -= timeToChange;

        currentHue = nextHue;
        nextHue = Random.value;
	}
}
