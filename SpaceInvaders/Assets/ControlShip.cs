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
				if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastMissileShot + 0.5f)
						Instantiate(missilePrefab, new Vector3(transform.position.x, -1.867158f), Quaternion.identity);
				//same as: float movement = Input.GetAxisRaw("Horizontal") * SpeedPerSecond;
				transform.position = new Vector3(transform.position.x + movement * Time.deltaTime, transform.position.y);
	}
		public GameObject missilePrefab;
		public float lastMissileShot = 0f;
	private const float SpeedPerSecond = 12;
}