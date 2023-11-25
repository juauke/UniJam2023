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

    public void ChangeWaterTemperature()
    {
        isFrozen = !isFrozen;
        this.GetComponent <PolygonCollider2D>().enabled = !isFrozen;
    }

    public void ChangeWaterConductivity()
    {
        isElectrified = !isElectrified;
    }

}
