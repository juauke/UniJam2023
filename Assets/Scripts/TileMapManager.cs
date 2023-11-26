using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour {
    public enum TypeTile {
        Floor = 0,
        Wall = 1,
        Water = 2
    }

    public class DataTile {
        public Tile tile;
        public int temperature = 1;
        public bool crystalIsPresent = false;
        public TypeTile type;
        public Vector3Int position;
        public SpriteRenderer spriteTile;
    }

    [SerializeField] private Tile[] _tileFloor;

    [SerializeField] private Tile[] _tileWater;

    [SerializeField] public Tilemap tileMap;

    [SerializeField]
    private GameObject _spriteTile;

    public Vector2Int topRight;

    public Vector2Int bottomLeft;

    public DataTile[,] _data = new DataTile[50, 50];

    public void Awake() {
        var size = topRight - bottomLeft;
        for (int i = 0; i <= size.x; i++) {
            for (int j = 0; j <= size.y; j++) {
                _data[j, i] = new DataTile();
                _data[j, i].position = new Vector3Int(bottomLeft.x + i, topRight.y - j, 0);
                _data[j, i].tile =
                    tileMap.GetTile<Tile>(
                        new Vector3Int(
                            bottomLeft.x + i,
                            topRight.y - j,
                            0)
                    );
                _data[j, i].spriteTile = Instantiate(_spriteTile,tileMap.GetCellCenterLocal(_data[j, i].position),Quaternion.identity).GetComponent<SpriteRenderer>();
                ;
                //Debug.Log(_data[j, i].tile.name);
                switch (_data[j, i].tile.name) {
                    case "BaseTile":
                        _data[j, i].type = TypeTile.Floor;
                        _data[j, i].spriteTile.sprite = _tileFloor[1].sprite;
                        break;
                    case "FireTile":
                        _data[j, i].type = TypeTile.Floor;

                        _data[j, i].spriteTile.sprite = _tileFloor[2].sprite;
                        break;
                    case "IceTile":
                        _data[j, i].type = TypeTile.Floor;
                        _data[j, i].spriteTile.sprite = _tileFloor[0].sprite;
                        break;
                    case "BaseWall":
                        _data[j, i].type = TypeTile.Wall;
                        break;
                    case "BaseWater":
                        _data[j, i].type = TypeTile.Water;
                        _data[j, i].spriteTile.sprite = _tileWater[1].sprite;
                        break;
                    case "FrozenWater":
                        _data[j, i].type = TypeTile.Water;
                        _data[j, i].spriteTile.sprite = _tileWater[0].sprite;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void UpdateTile(DataTile tile) {
        print("[DEBUG TILE WATER0] " + _tileWater[0].name);
        print("[DEBUG TILE WATER1] " + _tileWater[1].name);
        print("[DEBUG tile.type]" + tile.type);
        switch (tile.type) {
            case TypeTile.Floor:
                if (tile.temperature < 1) {
                    //tileMap.SetTile(tile.position, _tileFloor[0]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[0], Color.white, Matrix4x4.identity),
                        true);
                    tile.tile = _tileFloor[0];
                    tile.spriteTile.sprite = _tileFloor[0].sprite;
                }
                else if (tile.temperature > 1) {
                    //tileMap.SetTile(tile.position, _tileFloor[2]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[2], Color.white, Matrix4x4.identity),
                        true);
                    tile.tile = _tileFloor[2];
                    tile.spriteTile.sprite = _tileFloor[2].sprite;
                }
                else {
                    //tileMap.SetTile(tile.position, _tileFloor[1]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[1], Color.white, Matrix4x4.identity),
                        true);
                    tile.tile = _tileFloor[1];
                    tile.spriteTile.sprite = _tileFloor[1].sprite;
                }

                break;
            case TypeTile.Water:
                if (tile.temperature < 1) {
                    //tileMap.SetTile(tile.position, _tileWater[0]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileWater[0], Color.white, Matrix4x4.identity),
                        true);
                    tile.tile = _tileWater[0];
                    tile.spriteTile.sprite = _tileWater[0].sprite;
                }
                else {
                    //tileMap.SetTile(tile.position, _tileWater[1]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileWater[1], Color.white, Matrix4x4.identity),
                        true);
                    tile.tile = _tileWater[1];
                    tile.spriteTile.sprite = _tileWater[1].sprite;
                }

                break;
        }

        tileMap.RefreshAllTiles();
    }

    public DataTile getData(Vector3Int tilePosition) {
        return _data[topRight.y - (int)tilePosition.y, (int)tilePosition.x - bottomLeft.x];
    }
}