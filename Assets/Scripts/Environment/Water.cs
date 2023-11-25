using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isFrozen;
    public bool isElectrified;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TraversableCheck();
    }

    void TraversableCheck()
    {
        if (isFrozen)
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
}
