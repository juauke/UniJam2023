using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int speed;

    public Cristal cristal= null;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.MovePosition(new Vector3(0, 1 * speed * Time.deltaTime, 0) + transform.position);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(new Vector3(0, -1 * speed * Time.deltaTime, 0) + transform.position);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(new Vector3(-1 * speed * Time.deltaTime, 0, 0) + transform.position);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(new Vector3(1 * speed * Time.deltaTime, 0, 0) + transform.position);
        }
        if (Input.GetKey(KeyCode.Space))
        {
           cristal.Place(transform.position);
        }
    }

}
