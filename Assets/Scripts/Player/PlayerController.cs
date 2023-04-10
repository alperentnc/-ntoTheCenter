using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    [SerializeField] private LayerMask ground;
    public Animator animator;
    private float slowTimer = 3;
    public bool slow,slowPlatform;
    public float speed;
    public float slowSpeed;
    private bool isMoving;
    
    private Vector2 direction;

    private Vector2 initialTouchPos;
    public float minSwipeDistance;
    public float jumpForce = 2f;
    public float jumpTime = 0.5f;
    private bool isJumping;
    private float jumpTimer;
    public static bool meteorStarter=false;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        slow = false;
        slowPlatform = false;
    }

    void Update()
    {
        if (slow)
        {
            slowTimer -= Time.deltaTime;
        }
        if (slowTimer <= 0)
        {
            slowTimer = 3;
            slow = false;
        }
        if (slowPlatform == true)
        {
            speed = 1.5f;
            if (!IsGrounded())
            {
                speed = 3;
                slowPlatform = false;
            }
            
        }
        if (Input.touchCount > 0)
        {
            meteorStarter = true;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && IsGrounded())
            {
                isMoving = true;
                direction = Vector2.zero;
                initialTouchPos = touch.position; 
                if (slowTimer > 0 && slowTimer < 3 && slow)
                {
                    speed = 1.5f;
                }
                else
                {
                    speed = 3;
                }


            }
            else if (touch.phase == TouchPhase.Moved)
            {
               
                Vector2 touchDeltaPosition = touch.position - initialTouchPos;
                if (touchDeltaPosition.y > 200 && !isJumping && IsGrounded()) 
                {
                    isJumping = true;
                    jumpTimer = jumpTime;
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
                if(Mathf.Abs(touchDeltaPosition.x) >= minSwipeDistance)
                {
                    direction.x = Mathf.Sign(touchDeltaPosition.x);
                }
            }
            
            else if (touch.phase == TouchPhase.Ended)
            {
                isMoving = false;
               
            }
            


        }
        else
        {
            
            animator.SetBool("isWalking", false);
        }
        //if (transform.position.x >= 1.9f && 2.5f >= transform.position.x && transform.position.y <= -49)
        //{
        //    animator.SetBool("isFinish", true);
        //    rb.velocity = new Vector2(0, 0);
        //}


    }

    void FixedUpdate()
    {
        if (!IsGrounded())
        {
            animator.SetBool("isWalking", false);
        }
        if (isMoving)
        {
            if (IsGrounded())
            {
                rb.gravityScale = 1f;
                if (direction.x == -1)
                {
                    animator.SetBool("isWalking", true);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (direction.x == 1)
                {
                    animator.SetBool("isWalking", true);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); 
            }
            else
            {
                rb.gravityScale = .8f;
                if (direction.x == -1)
                {
                    animator.SetBool("isWalking", false);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (direction.x == 1)
                {
                    animator.SetBool("isWalking", false);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                rb.velocity = new Vector2(direction.x * speed*2/3, rb.velocity.y); 
            }
            
        }

        else if(!isMoving && IsGrounded())
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y); 
        }

        if (isJumping)
        {
            
            if (jumpTimer > 0.0f)
            {
                jumpTimer -= Time.fixedDeltaTime;
            }
            else
            {
                isJumping = false;
            }        
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("salivaBullet"))
        {
            slow = true;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftSlow") || collision.gameObject.CompareTag("RightSlow") || collision.gameObject.CompareTag("MidSlow"))
        {
            slowPlatform = true;
        }
    }

}


