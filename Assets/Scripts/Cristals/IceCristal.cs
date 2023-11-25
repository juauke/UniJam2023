using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCristal : Cristal
{
    // Start is called before the first frame update
    void Awake()
    {
        type = Element.Ice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public new void UpdateTiles()
    {
        Vector3 tilePosition = tile.transform.GetPosition();
        int x = (int)tilePosition.x;
        int y = (int)tilePosition.y;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Tile tileToUpdate = tileMapManager.tileMap.GetTile<Tile>(new Vector3Int(x + i, y+i, 0));
                if (tileMapManager.getData(tileToUpdate).temperature >-1)
                {
                    tileMapManager.getData(tileToUpdate).temperature--;
                }
                tileMapManager.UpdateTile(tileMapManager.getData(tileToUpdate));
            }
        }
    }
}
