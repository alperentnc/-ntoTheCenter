using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    Adds adds;
    void Start()
    {
        adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);
            adds.LoadFullSize();
            // Load the next level
        }
    }
}
