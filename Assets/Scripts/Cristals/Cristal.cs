using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cristal : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [SerializeField] private float sqrEpsilon = 1;

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
        if ((transform.position - player.transform.position).sqrMagnitude <= sqrEpsilon &&
            !player.cristal &&
            Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pick");
            player.cristal = this;
            gameObject.SetActive(false);
            UpdateTiles();
        }
    }

    public void Place(Vector3 position)
    {
        Debug.Log("place");
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(position);
        Vector3 cristalPosition = tileMapManager.tileMap.GetCellCenterLocal(tilePosition);
        transform.position = cristalPosition;
        Tile tile = tileMapManager.tileMap.GetTile<Tile>(tilePosition);
        tileMapManager.getData(tile).cristalIsPresent = true;
        gameObject.SetActive(true);
        UpdateTiles();
        player.cristal = null;

    }

    public virtual void UpdateTiles(){}
    
}
