using UnityEngine;

// ReSharper disable once UnusedMember.Global
// ReSharper disable once CheckNamespace
public class MissileCollider : MonoBehaviour {
	
	void Update ()
	{
		transform.position = new Vector3(transform.position.x,
			transform.position.y + MoveUpSpeed * Time.deltaTime);
		var enemies = FindObjectsOfType<EnemyAi>();
		foreach (var enemy in enemies)
			if (IsColliding(transform.position, enemy.transform.position))
				Destroy(enemy.gameObject);
		if (transform.position.y > 3.5f)
			Destroy(gameObject);
	}

	private static bool IsColliding(Vector3 missilePos, Vector3 enemyPos)
	{
		var w2 = 1.2f / 2;
		var h2 = 0.8f / 2;
		return missilePos.x > enemyPos.x - w2 && missilePos.x < enemyPos.x + w2 &&
			missilePos.y > enemyPos.y - h2 && missilePos.y < enemyPos.y + h2;
	}

	private const float MoveUpSpeed = 7.5f;
}
