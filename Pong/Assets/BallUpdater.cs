using UnityEngine;

public class BallUpdater : MonoBehaviour
{
	public Vector2 velocity = new Vector2(0.09f, 0.06f);
	private Vector2 size = new Vector2(0.4f, 0.4f);
	
	void FixedUpdate()
	{
		transform.position += (Vector3)velocity;
		if (transform.position.y + size.y / 2 > MoveLeftPaddle.GetScreenRect().yMax ||
				transform.position.y - size.y / 2 < MoveLeftPaddle.GetScreenRect().yMin)
			velocity.y *= -1f;
		if (transform.position.x + size.x / 2 > MoveLeftPaddle.GetScreenRect().xMax ||
				transform.position.x - size.x / 2 < MoveLeftPaddle.GetScreenRect().xMin)
			velocity.x *= -1f;
	}
}
