using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private int speed;
    [SerializeField] private float sqrEpsilon = 1;
    [SerializeField] private Transform grabRayStart;


    public Crystal crystal = null;

    private Rigidbody2D rb;

    [SerializeField] private GameObject pauseMenuCanvas;

    private Vector2 lookingDirection;

    private bool isSliding = false;

    [SerializeField] private PlayerAudioManager playerAudioManager;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private int horizontalMovement = 0;
    private int verticalMovement = 0;
    private int _currentSprite;
    private bool _currentFlip;

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
                    _spriteRenderer.sprite = sprites[_currentSprite -3];
                    _spriteRenderer.flipX = _currentFlip;
                    playerAudioManager.PlayDropSound();
                }
            }
            else {
                var colliderhit = Physics2D.Raycast(grabRayStart.position, lookingDirection, sqrEpsilon,
                    LayerMask.GetMask("Crystal")).collider;
                if (colliderhit && colliderhit.gameObject.TryGetComponent<Crystal>(out crystal)) {
                    crystal.Pick();
                    _spriteRenderer.sprite = sprites[_currentSprite +3];
                    _spriteRenderer.flipX = _currentFlip;
                    playerAudioManager.PlayTakeSound();
                }
            }
        }
    }

    void FixedUpdate()
    {
        verticalMovement = 0;
        horizontalMovement = 0;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) {
            verticalMovement++;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            verticalMovement--;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) {
            horizontalMovement--;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            horizontalMovement++;
        }

        rb.MovePosition(new Vector3(horizontalMovement, verticalMovement, 0) * (speed * Time.deltaTime) +
                        transform.position);
        playerAudioManager.PlayStepSound();
        int offsetCrystal = 0;
        if ((bool)crystal)
        {
            offsetCrystal = 3;
        }
        switch (horizontalMovement) {
            case -1:
                _spriteRenderer.sprite = sprites[2 + offsetCrystal];
                _spriteRenderer.flipX = true;
                _currentSprite = 2 + offsetCrystal;
                _currentFlip = true;
                lookingDirection = new Vector2(-1, 0);
                break;
            case 1:
                _spriteRenderer.sprite = sprites[2 + offsetCrystal];
                _spriteRenderer.flipX = false;
                lookingDirection = new Vector2(1, 0);
                _currentFlip = false;
                _currentSprite = 2 + offsetCrystal;
                break;
            default:
                switch (verticalMovement) {
                    case -1:
                        _spriteRenderer.sprite = sprites[1 + offsetCrystal];
                        _spriteRenderer.flipX = false;
                        lookingDirection = new Vector2(0, -1);
                        _currentFlip = false;
                        _currentSprite = 1 + offsetCrystal;
                        break;
                    case 1:
                        _spriteRenderer.sprite = sprites[offsetCrystal];
                        _spriteRenderer.flipX = false;
                        lookingDirection = new Vector2(0, 1);
                        _currentFlip = false;
                        _currentSprite = offsetCrystal;
                        break;
                    default:
                        break;
                }

                break;
        }
    }
}