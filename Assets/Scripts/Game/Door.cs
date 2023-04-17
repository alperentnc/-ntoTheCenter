using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
   

    void Start()
    {
        // Load the level that was last completed, or start at level 1 if none have been completed yet
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
           
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);
            // Load the next level
        }
    }
}
