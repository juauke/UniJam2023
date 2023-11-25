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
        public GameObject tile;
        public int temperature = 1;
        public bool cristalIsPresent;
        public TypeTile type;
        public Sprite sprite;
    }
    [SerializeField]
    private Sprite[][] _sprite;

    [SerializeField]
    private TileMap _tilemap;

    [SerializeField]
    public Vector2 topRight;

    [SerializeField]
    public Vector2 bottomLeft;

    [SerializeField] public Data_Tile[][] _data;

    public void Awake()
    {
        var size = bottomLeft - topRight;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                _data[j][i].tile = _tilemap.GetTile(new Vector2(bottomLeft.x + i, topRight.y - j));
                _data[j][i].sprite = _data[j][i].tile.GetComponent<Sprite>();
            }
        }

    }

    public void updateTile(Data_Tile tile)
    {
        tile.sprite = _sprite[(int)tile.type][tile.temperature];
    }
}