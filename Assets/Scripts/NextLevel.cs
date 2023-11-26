using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public Scene currentScene;

    private void OnTriggerEnter2D(Collider2D other) {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}