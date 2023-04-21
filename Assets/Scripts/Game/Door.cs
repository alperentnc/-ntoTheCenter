using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    Adds adds;
    void Start()
    {
        adds = gameObject.GetComponent<Adds>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
            adds.LoadFullSize();
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);
            // Load the next level
        }
    }
}
