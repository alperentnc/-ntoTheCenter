using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextLevelName;
    private int levelCompleted;

    void Start()
    {
        // Load the level that was last completed, or start at level 1 if none have been completed yet
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex);

            // Load the next level
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
