using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static bool levelComplete;
    public bool timerBool;
    Adds adds;
    GameObject[] enemy, meteor;
    public int enemyLength, meteorLength;
    public GameObject confetti;
    public float timer;
    void Start()
    {
        timer = 0;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        meteor = GameObject.FindGameObjectsWithTag("meteor");
        enemyLength = enemy.Length;
        meteorLength = meteor.Length;
        adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        levelComplete = false;
    }
    void Update()
    {
        if (timerBool == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 1.25f)
        {
            levelComplete = true;
            LevelsCoin.LevelCompleted = true;
            PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //AudioManager.Instance.MusicSource.Pause();

            AudioManager.Instance.PlaySFX("Win");
            //AudioManager.Instance.PlayMusic("Menu");
            for (int i = 0; i < enemyLength; i++)
            {
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }
            }
            for (int j = 0; j < meteorLength; j++)
            {
                //meteor[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                Destroy(meteor[j]);
            }
            // Save the current level as completed
            other.gameObject.GetComponent<Animator>().SetBool("isFinish", true);
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Instantiate(confetti, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0), Quaternion.identity);
            timerBool = true;
            
            
            // Load the next level
        }
        
    }
}
