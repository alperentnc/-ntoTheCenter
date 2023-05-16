using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalivaBullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer,animTimer;
    public Animator animator;
    private const string HealthKey = "PlayerHealth";
    public int health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        if (PlayerPrefs.HasKey(HealthKey))
        {
            health = PlayerPrefs.GetInt(HealthKey);
        }
    }

    void Update()
    {
        animTimer += Time.deltaTime;
        if (animTimer >= 0.3f)
        {
            animator.SetBool("isStop", true);
        }
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce the player's health
            health -= 5;

            // Save the player's health to PlayerPrefs
            PlayerPrefs.SetInt(HealthKey, health);
            collision.gameObject.GetComponent<PlayerHealth>().health -= 5;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
