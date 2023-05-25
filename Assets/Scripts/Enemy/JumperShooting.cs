using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperShooting : MonoBehaviour
{
    public GameObject redHit;
    [SerializeField] private LayerMask ground;
    private CapsuleCollider2D coll;
    public float bulletFrequency;
    private float timer;
    private GameObject player;
    public bool anims;
    public float fireDistance;
    JumperPatrolling jumperPatrolling;
    float yDifferance;
    bool catcher;
    public GameObject explode;
    public Animator animator;

    private const string HealthKey = "PlayerHealth";
    public int health;
    void Start()
    {
        anims = false;
        player = GameObject.FindGameObjectWithTag("Player");
        jumperPatrolling = gameObject.GetComponent<JumperPatrolling>();
        coll = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isShooting", false);

        if (PlayerPrefs.HasKey(HealthKey))
        {
            health = PlayerPrefs.GetInt(HealthKey);
        }
    }

    

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        yDifferance = player.transform.position.y - transform.position.y;
        if (distance < fireDistance && System.Math.Abs(yDifferance) <= 0.2f)
        {
            animator.SetBool("isShooting", true);
            if (transform.position.x <= player.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (IsGrounded() && yDifferance <= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, jumperPatrolling.speed*4/3 * Time.deltaTime);
            }
        }
        else
        {
            jumperPatrolling.Patroll();
            animator.SetBool("isShooting", false);
        }

        
        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (anims == false)
            {
                GameObject redHitObj = Instantiate(redHit, new Vector3(-0.3f, Camera.main.transform.position.y, 4), Quaternion.identity);
                GameObject explodingAnim = Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(explodingAnim, .5f);
                Destroy(redHitObj, .2f);
                anims = true;
            }
            
            // Reduce the player's health
            health -= 10;

            // Save the player's health to PlayerPrefs
            PlayerPrefs.SetInt(HealthKey, health);

            Destroy(gameObject);

            collision.gameObject.GetComponent<PlayerHealth>().health -= 20;

            Destroy(gameObject);
            AudioManager.Instance.PlaySFX("Explode");
            
            
            
        }
    }
}
