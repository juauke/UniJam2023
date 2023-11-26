using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private int speed;
    [SerializeField] private float sqrEpsilon = 1;
    [SerializeField] private Transform grabRayStart;


    [FormerlySerializedAs("cristal")] public Crystal crystal = null;

    private Rigidbody2D rb;

    [SerializeField] private GameObject pauseMenuCanvas;

    private Vector2 lookingDirection;

    private bool isSliding = false;

    [SerializeField] private PlayerAudioManager playerAudioManager;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenuCanvas.SetActive(!pauseMenuCanvas.activeSelf);
            playerAudioManager.PlaySelectSound();
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (crystal) {
                if (crystal.Place(transform.position + (Vector3)lookingDirection)) {
                    crystal = null;
                    playerAudioManager.PlayDropSound();
                }
            }
            else {
                var colliderhit = Physics2D.Raycast(grabRayStart.position, lookingDirection, sqrEpsilon,
                    LayerMask.GetMask("Crystal")).collider;
                if (colliderhit && colliderhit.gameObject.TryGetComponent<Crystal>(out crystal)) {
                    crystal.Pick();
                    playerAudioManager.PlayTakeSound();
                }
            }
        }
    }

    void FixedUpdate() {
        int horizontalMovement = 0;
        int verticalMovement = 0;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) {
            verticalMovement++;

            lookingDirection = new Vector2(0, 1);
            playerAudioManager.PlayStepSound();
            _spriteRenderer.sprite = sprites[0];
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            verticalMovement--;
            rb.MovePosition(new Vector3(0, -1 * speed * Time.deltaTime, 0) + transform.position);
            lookingDirection = new Vector2(0, -1);
            playerAudioManager.PlayStepSound();
            _spriteRenderer.sprite = sprites[1];
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) {
            horizontalMovement--;
            rb.MovePosition(new Vector3(-1 * speed * Time.deltaTime, 0, 0) + transform.position);
            lookingDirection = new Vector2(-1, 0);
            playerAudioManager.PlayStepSound();
            _spriteRenderer.sprite = sprites[2];
            _spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            horizontalMovement++;
            rb.MovePosition(new Vector3(1 * speed * Time.deltaTime, 0, 0) + transform.position);
            lookingDirection = new Vector2(1, 0);
            playerAudioManager.PlayStepSound();
            _spriteRenderer.sprite = sprites[2];
            _spriteRenderer.flipX = false;
        }

        rb.MovePosition(new Vector3(horizontalMovement, verticalMovement, 0) * (speed * Time.deltaTime) +
                        transform.position);
        playerAudioManager.PlayStepSound();
        switch (horizontalMovement) {
            case -1:
                _spriteRenderer.sprite = sprites[2];
                _spriteRenderer.flipX = true;
                break;
            case 1:
                _spriteRenderer.sprite = sprites[2];
                _spriteRenderer.flipX = false;
                break;
            default:
                switch (verticalMovement) {
                    case -1:
                        _spriteRenderer.sprite = sprites[1];
                        _spriteRenderer.flipX = false;
                        break;
                    case 1:
                        _spriteRenderer.sprite = sprites[0];
                        _spriteRenderer.flipX = false;
                        break;
                    default:
                        break;
                }

                break;
        }
    }
}