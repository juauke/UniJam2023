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
        public bool cristalIsPresent;
        public TypeTile type;
        public Sprite sprite;
    }
    [SerializeField]
    private Sprite[] _spriteFloor;

    [SerializeField]
    private Sprite[] _spriteWater;

    [SerializeField]
    public Tilemap tileMap;

    [SerializeField]
    public Vector2Int topRight;

    [SerializeField]
    public Vector2Int bottomLeft;

    [SerializeField] public Data_Tile[,] _data=new Data_Tile[50,50];

    public void Awake()
    {
        var size = topRight - bottomLeft;
        for (int i = 0; i <= size.x; i++)
        {
            for (int j = 0; j <= size.y; j++)
            {
                _data[j,i]=new Data_Tile();
                _data[j,i].tile = 
                    tileMap.GetTile<Tile>(
                    new Vector3Int(
                        bottomLeft.x + i, 
                        topRight.y - j,
                        0)
                    );
                _data[j,i].sprite = _data[j,i].tile.sprite;
                switch (_data[j,i].sprite.name)
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
                tile.sprite = _spriteFloor[tile.temperature];
                break;
            case TypeTile.Water:
                if (tile.temperature == 0)
                    tile.sprite = _spriteFloor[0];
                else
                    tile.sprite = _spriteFloor[1];
                break;
        }
    }

    public Data_Tile getData(Tile tile)
    {
        Vector3 tilePosition = tile.transform.GetPosition();
        return _data[(int)tilePosition.x,(int)tilePosition.y];
    }
}