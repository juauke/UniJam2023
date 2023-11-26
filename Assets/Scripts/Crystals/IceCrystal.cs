using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCrystal : Crystal
{
    // Start is called before the first frame update
    void Awake()
    {
        type = Element.Ice;
    }

    void Start()
    {
        UpdateTiles(-1);
    }


    public override void UpdateTiles(int factor)
    {
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(transform.position);
        int x = tilePosition.x;
        int y = tilePosition.y;
        int xmin = tileMapManager.bottomLeft.x;
        int xmax = tileMapManager.topRight.x;
        int ymin = tileMapManager.bottomLeft.y;
        int ymax = tileMapManager.topRight.y;
        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                if (math.abs(i * j) < 4 && x+i >= xmin && x+i<=xmax && y+j >= ymin && y+j <= ymax)
                {
                    var tileToUpdatePosition = new Vector3Int(x + i, y + j, 0);
                    Tile tileToUpdate = tileMapManager.tileMap.GetTile<Tile>(tileToUpdatePosition);
                    
                        tileMapManager.getData(tileToUpdatePosition).temperature += factor;
                    
                    tileMapManager.UpdateTile(tileMapManager.getData(tileToUpdatePosition));
                    
                }
            }
        }
    }
}
