using UnityEngine;

public class EndGame : MonoBehaviour {
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other) { UnityEngine.SceneManagement.SceneManager.LoadScene(2); }
}