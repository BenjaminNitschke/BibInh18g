using UnityEngine;

[ExecuteInEditMode]
public class MoveLeftPaddle : MonoBehaviour
{
	public GameObject Ball;
	private BallUpdater ballUpdater;
	public float Speed = 0.2f;
	
	private Vector2 size = new Vector2(0.25f, 1.25f);//transform.localScale isn't very useful
	public float Left { get { return transform.position.x - size.x / 2; } }
	public float Right { get { return transform.position.x + size.x / 2; } }
	public float Top { get { return transform.position.y + size.y / 2; } }
	public float Bottom { get { return transform.position.y - size.y / 2; } }

	void Start()
	{
		if (Ball == null)
			Ball = GameObject.Find("Ball");
		ballUpdater = Ball.GetComponent<BallUpdater>();
	}

	public static Rect GetScreenRect()
	{
		var ourCamera = Camera.main != null ? Camera.main : Camera.allCameras[0];
		float halfHeight = ourCamera.orthographicSize;
		float halfWidth = ourCamera.aspect * halfHeight;
		return new Rect(-halfWidth, -halfHeight, halfWidth * 2, halfHeight * 2);
	}

	void FixedUpdate()
	{
		float v = Input.GetAxisRaw("Vertical") * Speed;
		
		transform.position = new Vector3(GetScreenRect().xMin+0.6f, transform.position.y + v);
		if (transform.position.y < GetScreenRect().yMin)
			transform.position = new Vector2(transform.position.x, GetScreenRect().yMin);
		else if (transform.position.y > GetScreenRect().yMax)
			transform.position = new Vector2(transform.position.x, GetScreenRect().yMax);

		//Debug.Log("ball left="+ballUpdater.Left+", Paddle right="+Right);
		if (ballUpdater.Left > Right && ballUpdater.Left + ballUpdater.velocity.x <= Right &&
				ballUpdater.Bottom < Top && ballUpdater.Top > Bottom)
		{
			ballUpdater.velocity.x = Mathf.Abs(ballUpdater.velocity.x);
			// Where did we hit the paddle, if upper 20% or lower 20% change direction
			var paddleHitPosition = (Ball.transform.position.y - Bottom) / size.y;
			//Debug.Log("paddleHitPosition="+paddleHitPosition);
			if (paddleHitPosition < 0.2f)
				ballUpdater.velocity.y -= 0.1f;
			else if (paddleHitPosition > 0.8f)
				ballUpdater.velocity.y += 0.1f;
		}
	}
}