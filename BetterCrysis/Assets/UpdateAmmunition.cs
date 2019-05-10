using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmunition : MonoBehaviour
{
    private Text text;

    public int currentAmmunition = 100;

	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	void Update ()
    {
        text.text = "Munition: " + currentAmmunition;

        if (Input.GetKeyDown(KeyCode.R))
            currentAmmunition = 100;
	}
}
