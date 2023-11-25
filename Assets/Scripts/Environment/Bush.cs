using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField]
    private Sprite ashes;

    [SerializeField]
    private Sprite onFire;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("sucess");
            IsOnFire();
        }
    }
    public void IsOnFire()
    {
        GetComponent<SpriteRenderer>().sprite = onFire;
        //wait 1s
        GetComponent<SpriteRenderer>().sprite = ashes;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
