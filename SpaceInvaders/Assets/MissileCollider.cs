using UnityEngine;

// ReSharper disable once UnusedMember.Global
// ReSharper disable once CheckNamespace
public class MissileCollider : MonoBehaviour {

	void Update ()
	{
		transform.position = new Vector3(transform.position.x,
			transform.position.y + MoveUpSpeed * Time.deltaTime);
		//press space to fire next missile (max. 2 missiles per second)
		//if hit enemy with missile, kill enemy
		var enemies = GameObject.FindObjectsOfType<EnemyAi>();
		for (int i=0; i<enemies.Length; i++)
				{
						if (IsColliding(transform.position, enemy.transform.position))
								enemies[i].gameObject.SetActive(false);

				}
		}
		private static bool IsColliding(Vector3 missilePos, Vector3 enemyPos)
		{
				var w2 = 1.2f / 2;
				var h2 = 0.8f / 2;
				if (missilePos.y > enemyPos.y - h2 && missilePos.y < enemyPos.y + h2 &&
				missilePos.x > enemyPos.x - w2 && missilePos.x < enemyPos.x + w2)
						return true;
				return false;
		}
	private const float MoveUpSpeed = 7.5f;
}
