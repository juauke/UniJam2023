using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cristal : MonoBehaviour
{
    [SerializeField] private Transform player;

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
        if ((transform.position - player.position).sqrMagnitude <= sqrEpsilon &&
            Input.GetKeyDown("Space"))
        {
            // Faire en sorte que le player récupère le cristal (attendre qu'il soit implémenté)
            gameObject.SetActive(false);
        }
    }

    public void Place(Vector3 position)
    {
        Vector3Int tilePosition = new Vector3Int((int)MathF.Floor(position.x), (int)MathF.Floor(position.y), (int)MathF.Floor(position.z));
        transform.position = tilePosition;
        
    }
}
