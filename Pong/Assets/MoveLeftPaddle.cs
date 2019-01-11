using UnityEngine;

[ExecuteInEditMode]
public class MoveLeftPaddle : MonoBehaviour
{
	public float Speed = 0.2f;

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
	}
}