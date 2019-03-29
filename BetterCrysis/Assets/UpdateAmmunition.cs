using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmunition : MonoBehaviour
{
	public int CurrentAmmunition = 100;
	void Start () {}
	void Update ()
	{
		GetComponent<Text>().text = "Munition: " + CurrentAmmunition;
	}
}
