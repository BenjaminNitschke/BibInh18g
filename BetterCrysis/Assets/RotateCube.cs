using UnityEngine;

public class RotateCube : MonoBehaviour
{
	void Start() { }

	void Update()
	{
		transform.rotation = Quaternion.AngleAxis(180*Time.time, Vector3.forward);
	}
}
