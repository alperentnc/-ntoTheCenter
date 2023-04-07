using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGroup : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    PlayerController player;
    PlayerHealth playerHealth;
    public float timer;
    public float animTimer;
    public Animator anim;
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
                rb.velocity = new Vector2(0, -1);
            }

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Platform" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health = 0;

        }
    }
}
