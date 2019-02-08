using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverDisplay;

    private Text gameOverText;

    private List<EnemyController> enemies;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int enemiesPerRow;

    [SerializeField]
    private int numberOfRows;

    private void Awake()
    {
        gameOverText = gameOverDisplay.GetComponent<Text>();

        enemies = new List<EnemyController>();
    }

    void Start ()
    {
        CreateEnemies();
    }

    private void CreateEnemies()
    {
        float padding = 0.5f;
        Rect dimension = WorldHelper.Instance.GetWorldDimensions();
        float yStart = (dimension.yMax * 0.95f) - enemyPrefab.transform.localScale.y / 2f;
        float movableDistance = dimension.xMax * 2f;

        float spacePerEnemy = movableDistance / enemiesPerRow;

        float xOffset = -(movableDistance / 2f) + spacePerEnemy / 2f;

        for (int j= 0; j < numberOfRows; j++)
        {
            for (int i = 0; i < enemiesPerRow; i++)
            {
                float x = xOffset + ((spacePerEnemy) * i);
                float y = yStart - (enemyPrefab.transform.localScale.y + padding) * j;

                GameObject go = Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
                EnemyController enemy = go.GetComponent<EnemyController>();
                enemy.MovingDistance = spacePerEnemy / 2f;

                enemies.Add(enemy);
            }
        }
    }

    private void CheckWinCondition()
    {
        if (enemies.Count == 0)
            gameOverText.text = "You saved Hyrule!";
        else
        {
            PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            foreach(EnemyController enemy in enemies)
            {
                if(enemy.transform.position.y <= player.transform.position.y)
                {
                    gameOverText.text = "Nooo! Ganondorf has taken over!";
                    break;
                }
            }
        }
    }
	
	void Update ()
    {
        CheckWinCondition();
    }

    public List<EnemyController> Enemies
    {
        get
        {
            return enemies;
        }

        set
        {
            enemies = value;
        }
    }
}
