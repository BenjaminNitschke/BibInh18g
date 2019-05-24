using UnityEngine;

public class EnemyAi : MonoBehaviour
{
	void Start()
	{
		startPositionX = transform.position.x;
		velocity = SpeedPerSecond;
		offset = 0;
	}

	private float startPositionX;
	public float velocity = 0;
	private float offset = 0;
	private const float SpeedPerSecond = 3.0f;

	void Update ()
	{
		offset += velocity * Time.deltaTime;
		if (offset > MaximumOffset || offset < MinimumOffset)
		{
			velocity *= -1;
			offset += velocity * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, transform.position.y-MoveCloserToPlayerPerDirectionChange);
		}
		transform.position = new Vector3(startPositionX+offset, transform.position.y);
	}

	private const float MinimumOffset = -1.5f;
	private const float MaximumOffset = 1.5f;
	private const float MoveCloserToPlayerPerDirectionChange = 0.25f;
}
