using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextLevelName;
    public static int levelCompleted=1;

    void Start()
    {
        // Load the level that was last completed, or start at level 1 if none have been completed yet
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);

            // Load the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
