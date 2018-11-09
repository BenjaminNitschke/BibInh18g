using System.Collections;
using System.Collections.Generic;
using GameOfLife;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// https://unity3d.com/learn/tutorials/topics/2d-game-creation/intro-2d-world-building-w-tilemap
/// </summary>
public class GameOfLifeUpdater : MonoBehaviour {
	private Map map;
	private Tilemap tilemap;
	private Tile cellTile;

	// Use this for initialization
	void Start ()
	{
		tilemap = GetComponent<Tilemap>();
		cellTile = tilemap.GetTile<Tile>(new Vector3Int(5, -1, 0));
		//Create Map
		map = new Map(30, 20);
		map.Seed();
		//TODO: Fill map from unity editor data
		/*
		game = new Game(map.size.x, map.size.y);
		cellTile = map.GetTile<Tile>(new Vector3Int(5, -1, 0));
		rememberGliderGun = new Game(map.size.x, map.size.y/2);
		for (var x = 0; x < map.size.x; x++)
		for (var y = 0; y < map.size.y; y++)
		{
			bool isSet = map.HasTile(new Vector3Int(x + map.origin.x, y + map.origin.y, 0));
			game.Set(x, y, isSet);
			if (y >= rememberGliderGun.Height)
				rememberGliderGun.Set(x, y-rememberGliderGun.Height, isSet);
		}
		*/
	}
	
	// Update is called once per frame
	void Update ()
	{
		map.ExecuteNextStep();
		//Draw cells by updating tilemap
		for (var x = 0; x < map.current.GetLength(0); x++)
		for (var y = 0; y < map.current.GetLength(1); y++)
			tilemap.SetTile(new Vector3Int(x + tilemap.origin.x, y + tilemap.origin.y, 0),
				map.IsSet(x, y) ? cellTile : null);
	}
}
