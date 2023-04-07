using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGroup : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    PlayerController player;
    public float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            rb.velocity = new Vector2(0, -1);
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
            Debug.Log("oyunbýtýk");
        }
    }
}
