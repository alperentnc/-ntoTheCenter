using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player,redHit;
    GameObject redHitObj;
    private Rigidbody2D rb;
    public float force;
    private float timer,animTimer;
    public Animator animator;

    private const string HealthKey = "PlayerHealth";
    public int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0,rot);

        if (PlayerPrefs.HasKey(HealthKey))
        {
            health = PlayerPrefs.GetInt(HealthKey);
        }
    }

    void Update()
    {
        if(redHit != null)
        {
            redHitObj.transform.position= new Vector3(-0.3f, Camera.main.transform.position.y, 4);
        }
        timer += Time.deltaTime;
        animTimer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
        if (animTimer > .2f)
        {
            animator.SetBool("bulletStop", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce the player's health
            redHitObj = Instantiate(redHit, new Vector3(-0.3f, Camera.main.transform.position.y, 4), Quaternion.identity);
            Destroy(redHitObj,0.4f);
            health -= 10;

            // Save the player's health to PlayerPrefs
            PlayerPrefs.SetInt(HealthKey, health);

            collision.gameObject.GetComponent<PlayerHealth>().health -= 10;
            Debug.Log(health);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
