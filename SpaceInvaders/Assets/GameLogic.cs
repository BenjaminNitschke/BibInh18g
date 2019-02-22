using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
	void Start ()
	{
		text = GameObject.Find("GameOverText");
	}

	private GameObject text;
	
	void Update ()
	{
		var enemies = GameObject.FindObjectsOfType<EnemyAi>();
		if (enemies.Length == 0)
			text.GetComponent<Text>().text = "You defeated all enemies";
		else
		{
			for (int i=0; i<enemies.Length; i++)
				if (enemies[i].transform.position.y < -1.7f)
				{
					text.GetComponent<Text>().text = "Game Over. You Lose!";
					enemies[i].velocity = 0;
				}
		}
	}
}
