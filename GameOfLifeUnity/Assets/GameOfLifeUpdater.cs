using GameOfLife;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOfLifeUpdater : MonoBehaviour
{
	void Start()
	{
		//Initialize map
		map = new Map(20, 20);
		//apply Tilemap to map
		var tilemap = GetComponent<Tilemap>();
		cell = tilemap.GetTile(new Vector3Int(1, 1, 0));
		for (int x = -10; x < 10; x++)
		for (int y = -10; y < 10; y++)
		{
			var tile = tilemap.GetTile(new Vector3Int(x, y, 0));
			map.current[x + 10, y + 10] = tile != null;
		}
	}

	private Map map;
	private TileBase cell;
	private float timeToUpdate = 0;

	void Update()
	{
		timeToUpdate += Time.deltaTime;
		if (timeToUpdate > 1)
		{
			timeToUpdate -= 1;
			map.ExecuteNextStep();
			//map apply to Tilemap
			var tilemap = GetComponent<Tilemap>();
			for (int x = -10; x < 10; x++)
			for (int y = -10; y < 10; y++)
				tilemap.SetTile(new Vector3Int(x, y, 0), map.current[x + 10, y + 10] ? cell : null);
		}
	}
}