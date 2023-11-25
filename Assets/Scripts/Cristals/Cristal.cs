using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cristal : MonoBehaviour
{
    [SerializeField] private PlayerController player;


    public enum Element
    {
        Ice,
        Fire,
        Elec
    };

    [SerializeField] protected TileMapManager tileMapManager;


    public Element type;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Place(Vector3 position)
    {
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(position);
        Vector3 cristalPosition = tileMapManager.tileMap.GetCellCenterLocal(tilePosition);
        transform.position = cristalPosition;
        Tile tile = tileMapManager.tileMap.GetTile<Tile>(tilePosition);
        tileMapManager.getData(tile).cristalIsPresent = true;
        gameObject.SetActive(true);
        UpdateTiles(-1);

    }

    public void Pick()
    {
        gameObject.SetActive(false);
        UpdateTiles(1);
    }

    public virtual void UpdateTiles(int factor){}
    
}
