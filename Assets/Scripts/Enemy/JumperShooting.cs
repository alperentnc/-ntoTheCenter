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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jumperPatrolling = gameObject.GetComponent<JumperPatrolling>();
        coll = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        yDifferance = player.transform.position.y - transform.position.y;
        if (distance <= 0.1f)
        {
            Destroy(gameObject);
        }
        if (distance < fireDistance && System.Math.Abs(yDifferance) <= 0.2f)
        {
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
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, jumperPatrolling.speed * Time.deltaTime);
            }
        }
        else
        {
            jumperPatrolling.Patroll();
        }

        
        
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }

}
