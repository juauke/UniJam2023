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
    private Sprite[][] _sprite;

    [SerializeField]
    public Tilemap tileMap;

    [SerializeField]
    public Vector2Int topRight;

    [SerializeField]
    public Vector2Int bottomLeft;

    [SerializeField] public Data_Tile[][] _data;

    public void Awake()
    {
        var size = bottomLeft - topRight;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                _data[j][i].tile = tileMap.GetTile<Tile>(new Vector3Int(bottomLeft.x + i, topRight.y - j,0));
                _data[j][i].sprite = _data[j][i].tile.GetComponent<Sprite>();
            }
        }

    }

    public void UpdateTile(Data_Tile tile)
    {
        tile.sprite = _sprite[(int)tile.type][tile.temperature];
    }

    public Data_Tile getData(Tile tile)
    {
        Vector3 tilePosition = tile.transform.GetPosition();
        return _data[(int)tilePosition.x][(int)tilePosition.y];
    }
}