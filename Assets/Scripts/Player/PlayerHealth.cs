using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    public int maxHalth = 100;
    public int health = 100;
    public bool isGameOver = false,isLoading,notYet;
    Adds adds;
    public static bool freezer;
    GameObject[] enemy,meteor;
    public int enemyLength, meteorLength;
    public GameObject bom;
    GameObject player,bomber;
    public float timer;

    private const string HealthKey = "PlayerHealth";

    void Start()
    {
        notYet = false;
        isGameOver = false;
        freezer = false;
        isLoading = false;
        adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        PlayerPrefs.SetInt(HealthKey, health);
       
        if (PlayerPrefs.GetInt("IndexHealth") == 0)
        {
            PlayerPrefs.SetInt(HealthKey, 100);
        }
        else
        {
            PlayerPrefs.SetInt(HealthKey, (PlayerPrefs.GetInt("IndexHealth")) * 10 + 100);
        }
        // Load the player's health from PlayerPrefs, if it exists
        if (PlayerPrefs.HasKey(HealthKey))
        {
            maxHalth = PlayerPrefs.GetInt(HealthKey);
        }

        health = maxHalth;
        slider.maxValue = maxHalth;
        slider.value = health;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        meteor = GameObject.FindGameObjectsWithTag("meteor");
        Debug.Log("health" + health);
        enemyLength = enemy.Length;
        meteorLength = meteor.Length;
        // Update the health slider
        slider.value = health;
        if (freezer == true || PauseMenu.pause)
        {
            Time.timeScale = 0f;
        }

        else { Time.timeScale = 1f; }
        
        // Check if the player has run out of health
        if (health <= 0 && Door.levelComplete==false)
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
                if(meteor[j] != null)
                {
                    //meteor[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    Destroy(meteor[j]);
                }
                
            }
            PlayerController.meteorStarter = false;
            //isGameOver = true;
            if (!isLoading)
            {
                isLoading=true;
            }
            

        }

        if (health <= 0)
        {
            if (notYet == false)
            {
                bomber = Instantiate(bom, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
                Destroy(bomber, 0.3f);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 100);
                notYet = true;
            }
            
            timer += Time.deltaTime;
            if (timer >= 0.3f)
            {
                isGameOver = true;
            }
            

            for (int i = 0; i < enemyLength; i++)
            {
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }
            }
            for (int j = 0; j < meteorLength; j++)
            {
                if (meteor[j] != null)
                {
                    Destroy(meteor[j]);
                }

            }
        }

        else
        {
            isGameOver = false;
            //Time.timeScale = 1f;
        }
    }
}
