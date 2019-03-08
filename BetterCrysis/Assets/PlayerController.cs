using UnityEngine;

public class PlayerController : MonoBehaviour
{
	void Update ()
	{
		transform.position += MoveSpeed * transform.forward * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Rotate(0, RotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
	}

	private const float MoveSpeed = 5.0f;
	private const float RotateSpeed = 180f;
}