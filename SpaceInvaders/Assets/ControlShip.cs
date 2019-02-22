using UnityEngine;

public class ControlShip : MonoBehaviour
{
	void Update()
	{
		float movement = 0;
		if (Input.GetKey(KeyCode.LeftArrow))
			movement = -Speed;
		else if (Input.GetKey(KeyCode.RightArrow))
			movement = Speed;
		//same as: float movement = Input.GetAxisRaw("Horizontal") * Speed;
		transform.position = new Vector3(transform.position.x + movement, transform.position.y);
	}

	private const float Speed = 0.2f;
}