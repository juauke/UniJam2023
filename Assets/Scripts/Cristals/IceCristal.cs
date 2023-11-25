using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceCristal : Cristal
{
    // Start is called before the first frame update
    void Awake()
    {
        type = Element.Ice;
    }


    public override void UpdateTiles()
    {
        //tileMapManager.tileMap.WorldToCell() position de la cellule
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(transform.position);
        int x = tilePosition.x;
        int y = tilePosition.y;
        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                if (math.abs(i * j) < 4)
                {
                    Tile tileToUpdate = tileMapManager.tileMap.GetTile<Tile>(new Vector3Int(x + i, y+i, 0));
                    
                        tileMapManager.getData(tileToUpdate).temperature--;
                    
                    tileMapManager.UpdateTile(tileMapManager.getData(tileToUpdate));
                    
                }
            }
        }
    }
}
