using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private int offset;

    [SerializeField] private Tile grassTile, secondGrassTile;
    [SerializeField] private Camera cam;

    private int x, y;
    
    public static GridManager Instance;
    public GameObject BaseUnit_Object;

    public Transform selector;
    public Dictionary<Vector2, Tile> tiles;

    public Cinemachine.CinemachineVirtualCamera VirtualCamera;
    public GameObject CombatPos;
    public GameObject PrincessDress;
    public Vector2 LastPrincessPos;
    
   
    void Awake()
    { 
        Instance = this;
    }
    public void GenerateGrid()
    {
        //BaseUnit_Object.GetComponent<BaseUnit>().IsEnemyDead = false;
        //BaseUnit_Object.GetComponent<BaseUnit>().IsPrincessDead = false;

        tiles = new Dictionary<Vector2, Tile>();
        for (x = 100; x < offset + width; x++)
        {
            for (y = 0; y < height; y++)
            {
               
                var randomTile = Random.Range(0, 6) == 3 ? secondGrassTile : grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(x, y, this);
                tiles[new Vector2(x, y)] = spawnedTile;
                
                //x = xpos;
                //y = ypos;
            }
        }
        //cam.transform.position = new Vector3((float)(offset + width) / 2 - 0.5f, (float)(height) / 2 - 0.5f, -10);
        VirtualCamera.Follow =  CombatPos.transform;
        LastPrincessPos = PrincessDress.transform.position;
        PrincessDress.transform.position = new Vector2(10000, 10000);
        FightManager.Instance.ChangeState(FightManager.Gamestate.SpawnPrincess);
    }

    public Tile GetPrincessSpawnTile()
    {
        return tiles.Where(t => t.Key.x < offset + width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnnemySpawnTile()
    {
        return tiles.Where(t => t.Key.x > offset + width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }

   
}
