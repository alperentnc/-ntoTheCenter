using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static bool levelComplete;
    Adds adds;
    void Start()
    {
        adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        levelComplete = false;
    }
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Save the current level as completed
            levelComplete = true;
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);
            adds.LoadFullSize();
            // Load the next level
        }
    }
}
