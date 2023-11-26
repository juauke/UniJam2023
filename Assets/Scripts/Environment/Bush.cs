using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bush : MonoBehaviour
{
    [SerializeField]
    private Sprite ashes;

    [SerializeField]
    private Sprite onFire;

    [SerializeField]
    private Sprite bush;

    [SerializeField] 
    protected TileMapManager tileMapManager;


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            StartCoroutine(BurningDown());
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            StartCoroutine(FireUp());
        }

        DetectTemperatureTile(transform.position);

    }
    public IEnumerator BurningDown()
    {
        GetComponent<SpriteRenderer>().sprite = onFire;

        yield return new WaitForSecondsRealtime(1);

        GetComponent<SpriteRenderer>().sprite = ashes;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public IEnumerator FireUp()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = onFire;

        yield return new WaitForSecondsRealtime(1);

        GetComponent<SpriteRenderer>().sprite = bush;
    }

    void DetectTemperatureTile(Vector3 position)
    {
        Vector3Int tilePosition = tileMapManager.tileMap.WorldToCell(position);
        TileMapManager.DataTile data = tileMapManager.getData(tilePosition);

        if (data.temperature >= 2 && GetComponent<SpriteRenderer>().sprite == bush)
        {
            StartCoroutine(BurningDown());
        }

        else if(data.temperature <=1 && GetComponent<SpriteRenderer>().sprite == ashes)
        {
            StartCoroutine(FireUp());
        }
    }
}
