using System.Collections;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ChangingTile : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField] SpriteRenderer _spriteRenderer;

    public int Temperature=1;
    
    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.sprite = _sprites[Temperature];
    }
}

