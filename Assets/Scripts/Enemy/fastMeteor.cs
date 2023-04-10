using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    PlayerController player;
    PlayerHealth playerHealth;
    public float min,max;
    private float timer, meteorStartTimer;
    void Start()
    {
        meteorStartTimer = Random.Range(min, max);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.meteorStarter == true) 
        {
            timer += Time.deltaTime;
            if (timer>meteorStartTimer)
            {
                rb.velocity = new Vector2(0, -7);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health = 0;

        }
    }
}
