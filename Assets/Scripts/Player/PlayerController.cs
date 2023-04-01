using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    [SerializeField] private LayerMask ground;
    private Vector2 screenBounds;
    public Animator animator;
    private Vector2 touchStartPosition;
    private bool isSwipeStarted;
    private float slowTimer = 3;
    private bool slow;
    public float speed;
    public float slowSpeed;
    private bool isMoving;
    
    private Vector2 direction;

    private Vector2 initialTouchPos; // Initial position of touch input
    public float minSwipeDistance;
    public float jumpForce = 2f;
    public float jumpTime = 0.5f;
    private bool isJumping;
    private float jumpTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        slow = false;
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && IsGrounded())
            {
                isMoving = true;
                direction = Vector2.zero;
                initialTouchPos = touch.position; // Record the initial position of touch input
                if (slowTimer > 0 && slowTimer < 3 && slow)
                {
                    speed = 1.5f;
                    Debug.Log(slow);
                }
                else
                {
                    speed = 3;
                }


            }
            else if (touch.phase == TouchPhase.Moved) // Check if the touch input is currently moving
            {
               
                Vector2 touchDeltaPosition = touch.position - initialTouchPos;
                if (touchDeltaPosition.y > 30 && !isJumping) // Check if the touch input is moving upwards and the character is not already jumping
                {
                    isJumping = true;
                }
                if(Mathf.Abs(touchDeltaPosition.x) >= minSwipeDistance)
                {
                    direction.x = Mathf.Sign(touchDeltaPosition.x); // Get the sign of the x component to determine direction
                }
            }
            
            else if (touch.phase == TouchPhase.Ended) // Check if the touch input just ended
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
        if (isMoving && IsGrounded())
        {
            if (direction.x == -1)
            {
                animator.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
                Debug.Log("left");
            }
            else if (direction.x == 1)
            {
                animator.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("right");
            }
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); // Apply velocity to character's Rigidbody2D component
        }

        else if(!isMoving && IsGrounded())
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y); // Stop the character's horizontal movement
        }

        if (isJumping)
        {
            if (IsGrounded())
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                // rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
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
}


