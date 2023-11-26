using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField]
    private Sprite ashes;

    [SerializeField]
    private Sprite onFire;

    [SerializeField]
    private Sprite bush;

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
        GetComponent <SpriteRenderer>().sprite = onFire;

        yield return new WaitForSecondsRealtime(1);

        GetComponent <SpriteRenderer>().sprite = bush;
    }
}
