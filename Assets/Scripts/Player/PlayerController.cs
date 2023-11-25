using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int speed;
    [SerializeField] private float sqrEpsilon = 1;

    public Cristal cristal= null;

    private Rigidbody2D rb;

    [SerializeField]
    private GameObject pauseMenuCanvas;

    private Vector2 lookingDirection;
    
    private bool isSliding = false;

    [SerializeField]
    private GameObject AudioManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuCanvas.SetActive(!pauseMenuCanvas.activeSelf);
            AudioManager.GetComponent<PlayerAudioManager>().PlaySelectSound();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(new Vector3(0, 1 * speed * Time.deltaTime, 0) + transform.position);
            lookingDirection = new Vector2 (0, 1);
            AudioManager.GetComponent<PlayerAudioManager>().PlayStepSound();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(new Vector3(0, -1 * speed * Time.deltaTime, 0) + transform.position);
            lookingDirection =  new Vector2(0, -1);
            AudioManager.GetComponent<PlayerAudioManager>().PlayStepSound();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(new Vector3(-1 * speed * Time.deltaTime, 0, 0) + transform.position);
            lookingDirection =  new Vector2(-1, 0);
            AudioManager.GetComponent<PlayerAudioManager>().PlayStepSound();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(new Vector3(1 * speed * Time.deltaTime, 0, 0) + transform.position);
            lookingDirection =  new Vector2(1, 0);
            AudioManager.GetComponent<PlayerAudioManager>().PlayStepSound();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (cristal)
            {
                cristal.Place(transform.position);
                cristal = null;
                AudioManager.GetComponent<PlayerAudioManager>().PlayDropSound();
            }
            else
            {
                var colliderhit = Physics2D.Raycast(transform.position, lookingDirection, sqrEpsilon).collider;
                if (colliderhit && colliderhit.gameObject.TryGetComponent<Cristal>(out cristal))
                {
                    cristal.Pick();
                    AudioManager.GetComponent<PlayerAudioManager>().PlayTakeSound();
                }
            }
           
        }
    }

}
