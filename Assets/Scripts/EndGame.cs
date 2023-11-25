using UnityEngine;

public class EndGame : MonoBehaviour {
    [SerializeField] private GameObject player;

    private void OnTrigger2DEnter(Collider2D other) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}