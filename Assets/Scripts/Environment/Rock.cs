using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private float pushForce = 10f;  // Adjust the force as needed
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // You might want to use FixedUpdate instead of Update for physics-related operations
    void FixedUpdate()
    {
        // Get the player's position
        Vector2 playerPosition = player.transform.position;

        // Calculate the direction from the player to this object
        Vector2 pushDirection = (playerPosition - (Vector2)transform.position).normalized;

        // Apply force to the rigidbody
        if (this.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<PolygonCollider2D>()))
        {
           rb.velocity = -(pushDirection * pushForce);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }
}
