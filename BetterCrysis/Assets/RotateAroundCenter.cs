using UnityEngine;

public class RotateAroundCenter : MonoBehaviour
{
	void Update ()
	{
		transform.RotateAround(Vector3.zero, Vector3.up, 180*Time.deltaTime);
	}
}