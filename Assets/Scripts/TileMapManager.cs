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
        public TileBase tile;
        public int temperature = 1;
        public bool crystalIsPresent = false;
        public TypeTile type;
        public Vector3Int position;
    }

    [SerializeField] private Tile[] _tileFloor;

    [SerializeField] private Tile[] _tileWater;

    [SerializeField] public Tilemap tileMap;

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
                ;
                Debug.Log(_data[j, i].tile.name);
                switch (_data[j, i].tile.name) {
                    case "BaseTile":
                        _data[j, i].type = TypeTile.Floor;
                        break;
                    case "FireTile":
                        _data[j, i].type = TypeTile.Floor;
                        break;
                    case "IceTile":
                        _data[j, i].type = TypeTile.Floor;
                        break;
                    case "BaseWall":
                        _data[j, i].type = TypeTile.Wall;
                        break;
                    case "BaseWater":
                        _data[j, i].type = TypeTile.Water;
                        break;
                    case "FrozenWater":
                        _data[j, i].type = TypeTile.Water;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void UpdateTile(DataTile tile) {
        switch (tile.type) {
            case TypeTile.Floor:
                if (tile.temperature < 1) {
                    //tileMap.SetTile(tile.position, _tileFloor[0]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[0], Color.white, Matrix4x4.identity),true);
                    tile.tile = _tileFloor[0];
                }
                else if (tile.temperature > 1) {
                    //tileMap.SetTile(tile.position, _tileFloor[2]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[2], Color.white, Matrix4x4.identity), true);
                    tile.tile = _tileFloor[2];
                }
                else {
                    //tileMap.SetTile(tile.position, _tileFloor[1]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileFloor[1], Color.white, Matrix4x4.identity), true);
                    tile.tile = _tileFloor[1];
                }

                break;
            case TypeTile.Water:
                if (tile.temperature < 1) {
                    //tileMap.SetTile(tile.position, _tileWater[0]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileWater[0], Color.white, Matrix4x4.identity), true);
                    tile.tile = _tileWater[0];
                }
                else {
                    //tileMap.SetTile(tile.position, _tileWater[1]);
                    tileMap.SetTile(new TileChangeData(tile.position, _tileWater[0], Color.white, Matrix4x4.identity), true);
                    tile.tile = _tileWater[1];
                }

                break;
        }
    }

    public DataTile getData(Vector3Int tilePosition) {
        return _data[topRight.y - (int)tilePosition.y, (int)tilePosition.x - bottomLeft.x];
    }
}