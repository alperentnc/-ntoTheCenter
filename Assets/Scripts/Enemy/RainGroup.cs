using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGroup : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    PlayerController player;
    PlayerHealth playerHealth;
    public float timer,meteorSpeed;
    public Animator anim;

    private const string HealthKey = "PlayerHealth";
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isStarting", false);
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.meteorStarter == true)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                anim.SetBool("isStarting", true);
                rb.velocity = new Vector2(0, -meteorSpeed);
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
            playerHealth.health -= 100;
            PlayerPrefs.SetInt(HealthKey, playerHealth.health);
        }
    }

}
