using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static bool levelComplete;
    Adds adds;
    GameObject[] enemy, meteor;
    public int enemyLength, meteorLength;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        meteor = GameObject.FindGameObjectsWithTag("meteor");
        enemyLength = enemy.Length;
        meteorLength = meteor.Length;
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
            for (int i = 0; i < enemyLength; i++)
            {
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }
            }
            for (int j = 0; j < meteorLength; j++)
            {
                meteor[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            // Save the current level as completed
            levelComplete = true;
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex+1);
            adds.LoadFullSize();
            // Load the next level
        }
    }
}
