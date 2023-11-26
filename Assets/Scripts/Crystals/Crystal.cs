using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crystal : MonoBehaviour {
    [SerializeField] private PlayerController player;


    public enum Element {
        Ice,
        Fire,
        Elec
    };

    [SerializeField] protected TileMapManager tileMapManager;


    public Element type;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public bool Place(Vector3 position) {
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(position);
        Vector3 crystalPosition = tileMapManager.tileMap.GetCellCenterLocal(tilePosition);
        TileMapManager.DataTile data = tileMapManager.getData(tilePosition);
        if (!data.crystalIsPresent && data.type == TileMapManager.TypeTile.Floor) {
            transform.position = crystalPosition;
            data.crystalIsPresent = true;
            gameObject.SetActive(true);
            UpdateTiles(-1);
            return true;
        }

        return false;
    }

    public void Pick() {
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(transform.position);
        TileMapManager.DataTile data = tileMapManager.getData(tilePosition);
        data.crystalIsPresent = false;
        gameObject.SetActive(false);
        UpdateTiles(1);
    }

    public virtual void UpdateTiles(int factor) { }
}