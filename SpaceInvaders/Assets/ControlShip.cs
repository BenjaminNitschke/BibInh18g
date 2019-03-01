using UnityEngine;

public class ControlShip : MonoBehaviour
{
	void Update()
	{
		float movement = 0;
		if (Input.GetKey(KeyCode.LeftArrow))
			movement = -SpeedPerSecond;
		else if (Input.GetKey(KeyCode.RightArrow))
			movement = SpeedPerSecond;
		if (Input.GetKey(KeyCode.Space) && Time.time > lastTimeMissileShot + 0.5f)
		{
			Instantiate(missilePrefab, new Vector3(transform.position.x, -1.867158f), Quaternion.identity);
			lastTimeMissileShot = Time.time;
		}

		//same as: float movement = Input.GetAxisRaw("Horizontal") * SpeedPerFrame;
		transform.position = new Vector3(transform.position.x + movement * Time.deltaTime, transform.position.y);
	}

	public GameObject missilePrefab;
	private float lastTimeMissileShot = 0;
	private const float SpeedPerSecond = 12;
}