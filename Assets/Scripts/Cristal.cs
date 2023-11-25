using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cristal : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [SerializeField] private float sqrEpsilon;
    
    public enum Element {Ice, Fire, Elec};

    [SerializeField] private Tilemap tilemap;

    public Element type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).sqrMagnitude <= sqrEpsilon &&
            Input.GetKeyDown("Space"))
        {
            player.cristal = this;
            gameObject.SetActive(false);
        }
    }

    public void Place(Vector3 position)
    {
        player.cristal = null;
        Vector3Int tilePosition = new Vector3Int((int)MathF.Floor(position.x), (int)MathF.Floor(position.y), (int)MathF.Floor(position.z));
        transform.position = tilePosition;
        gameObject.SetActive(true);
    }
}
