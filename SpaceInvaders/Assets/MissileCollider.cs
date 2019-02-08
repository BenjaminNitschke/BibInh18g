using UnityEngine;

public class MissileCollider : MonoBehaviour {
	
	void Update ()
	{
		transform.position = new Vector3(transform.position.x,
			transform.position.y + MoveUpSpeed * Time.deltaTime);
		//press space to fire next missile (max. 2 missiles per second)
		//if hit enemy with missile, kill enemy
		var enemies = GameObject.FindObjectsOfType<EnemyAi>();
		for (int i=0; i<enemies.Length; i++)
			if (transform.position.y > enemies[i].transform.position.y)
				enemies[i].gameObject.SetActive(false);
	}

	private const float MoveUpSpeed = 7.5f;
}
