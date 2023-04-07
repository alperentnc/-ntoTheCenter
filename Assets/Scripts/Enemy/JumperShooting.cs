using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperShooting : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    private CapsuleCollider2D coll;
    public float bulletFrequency;
    private float timer;
    private GameObject player;
    public float fireDistance;
    JumperPatrolling jumperPatrolling;
    float yDifferance;
    bool catcher;
    public GameObject explode;
    public Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jumperPatrolling = gameObject.GetComponent<JumperPatrolling>();
        coll = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isShooting", false);
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
            collision.gameObject.GetComponent<PlayerHealth>().health -= 30;
            GameObject explodingAnim =  Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explodingAnim, .5f);
        }
    }
}
