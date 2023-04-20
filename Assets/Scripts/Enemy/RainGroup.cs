using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGroup : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    private PlayerController player;
    private PlayerHealth playerHealth;
    public float timer,meteorSpeed;

    private const string HealthKey = "PlayerHealth";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        timer = 0;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.meteorStarter == true)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                rb.velocity = new Vector2(0, -meteorSpeed);
                if (transform.position.y >= Camera.main.transform.position.y+10)
                {
                    transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y+8, transform.position.z);
                }
            }
            

        }
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="MiddlePlatform" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "LeftPlatform" || collision.gameObject.tag == "RightPlatform" ||
            collision.gameObject.tag == "LeftSlow" || collision.gameObject.tag == "RightSlow" || collision.gameObject.tag == "MidSlow")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health = 0;
            PlayerPrefs.SetInt(HealthKey, playerHealth.health);
        }
    }

}
