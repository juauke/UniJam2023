using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    public enum TypeTile
    {
        Floor = 0,
        Wall = 1,
        Water = 2
    }

    public class Data_Tile
    {
        public Tile tile;
        public int temperature = 1;
        public bool cristalIsPresent=false;
        public TypeTile type;
        public Vector3Int position;
    }
    [SerializeField]
    private Tile[] _tileFloor;

    [SerializeField]
    private Tile[] _tileWater;

    [SerializeField]
    public Tilemap tileMap;

    public Vector2Int topRight;

    public Vector2Int bottomLeft;
    
    public Data_Tile[,] _data=new Data_Tile[50,50];

    public void Awake()
    {
        var size = topRight - bottomLeft;
        for (int i = 0; i <= size.x; i++)
        {
            for (int j = 0; j <= size.y; j++)
            {
                _data[j,i]=new Data_Tile();
                _data[j,i].position= new Vector3Int(bottomLeft.x + i, topRight.y - j, 0);
                _data[j,i].tile = 
                    tileMap.GetTile<Tile>(
                    new Vector3Int(
                        bottomLeft.x + i, 
                        topRight.y - j,
                        0)
                    );;
                Debug.Log(_data[j, i].tile.name);
                switch (_data[j,i].tile.name)
                { 
                    case "casebase" :
                        _data[j,i].type = TypeTile.Floor;
                        break;
                    case "casefeu":
                        _data[j,i].type = TypeTile.Floor;
                        break;
                    case "caseglace":
                        _data[j,i].type = TypeTile.Floor;
                        break;
                    case "murbase":
                        _data[j,i].type = TypeTile.Wall;
                        break;
                    case "eaubase":
                        _data[j,i].type = TypeTile.Water;
                        break;
                    case "eaugelée":
                        _data[j,i].type = TypeTile.Water;
                        break;
                    default:
                        break;

                }
            }
        }

    }

    public void UpdateTile(Data_Tile tile)
    {
        switch (tile.type)
        {
            case TypeTile.Floor:
                if (tile.temperature < 1)
                {
                    tileMap.SetTile(tile.position, _tileFloor[0]);
                    tile.tile = _tileFloor[0];
                }
                else if (tile.temperature > 1)
                {
                    tileMap.SetTile(tile.position, _tileFloor[2]);
                    tile.tile = _tileFloor[2];
                }
                else
                {
                    tileMap.SetTile(tile.position, _tileFloor[1]);
                    tile.tile = _tileFloor[1];
                }
                break;
            case TypeTile.Water:
                if (tile.temperature < 1)
                {
                    tileMap.SetTile(tile.position, _tileWater[0]);
                    tile.tile = _tileWater[0];
                }
                else
                {
                    tileMap.SetTile(tile.position, _tileWater[1]);
                    tile.tile = _tileWater[1];
                }

                break;
        }
    }

    public Data_Tile getData(Tile tile)
    {
        Vector3 tilePosition = tile.transform.GetPosition();
        return _data[(int)tilePosition.x,(int)tilePosition.y];
    }
}