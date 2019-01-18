using UnityEngine;

public class BallUpdater : MonoBehaviour
{
	public Vector2 velocity = new Vector2(0.09f, 0.06f);
	private Vector2 size = new Vector2(0.4f, 0.4f);//transform.localScale isn't very useful
	public float Left { get { return transform.position.x - size.x / 2; } }
	public float Right { get { return transform.position.x + size.x / 2; } }
	public float Top { get { return transform.position.y + size.y / 2; } }
	public float Bottom { get { return transform.position.y - size.y / 2; } }
	
	void FixedUpdate()
	{
		transform.position += (Vector3)velocity;
		if (Top > MoveLeftPaddle.GetScreenRect().yMax ||
				Bottom < MoveLeftPaddle.GetScreenRect().yMin)
			velocity.y *= -1f;
		if (Right > MoveLeftPaddle.GetScreenRect().xMax ||
				Left < MoveLeftPaddle.GetScreenRect().xMin)
			velocity.x *= -1f;
	}
}
