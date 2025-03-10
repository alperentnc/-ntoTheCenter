using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    public GameObject hitSaliva,hitElectric;
    GameObject hitSalivaObj,hitElectricObj;
    [SerializeField] private LayerMask ground;
    public Animator animator;
    private float slowTimer = 3;
    private float stunTimer=1;
    public bool slow,slowPlatform,stun;
    public float speed;
    private bool isMoving;
    //public float normalSpeed;
    //public float slowSpeed;

    private Vector2 direction;

    private Vector2 initialTouchPos;
    public float minSwipeDistance;
    public float jumpForce = 2f;
    public float jumpTime = 0.5f;
    public bool isJumping,isGreenHit,isElectricHit;
    private float jumpTimer;
    public static bool meteorStarter=false;

    private const string NormalSpeedKey = "PlayerSpeed";
    private const string SlowSpeedKey = "PlayerSpeed";


    void Start()
    {
        isGreenHit = false;
        isElectricHit = false;
        //PlayerPrefs.SetInt("Diamond",8);
        if (PlayerPrefs.GetInt("IndexHealth") + 1 == 0)
        {
            PlayerPrefs.SetFloat(NormalSpeedKey, 6f);
            PlayerPrefs.SetFloat(SlowSpeedKey, 3f);
        }
        else
        {
            PlayerPrefs.SetFloat(NormalSpeedKey, (PlayerPrefs.GetInt("IndexSpeed")) * .15f + 6f);
            PlayerPrefs.SetFloat(SlowSpeedKey, (PlayerPrefs.GetInt("IndexSpeed")) * .3f + 3f);
        }

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        slow = false;
        stun = false;
        slowPlatform = false;
        meteorStarter = false;
        AudioManager.Instance.PlayMusic("Game");
    }

    void Update()
    {
        if (slowPlatform == true)
        {
            speed = PlayerPrefs.GetFloat(SlowSpeedKey)/2;
            if (!IsGrounded())
            {
                speed = PlayerPrefs.GetFloat(NormalSpeedKey);
                slowPlatform = false;
                if(hitSalivaObj != null)
                {
                    Destroy(hitSalivaObj);
                    isGreenHit = false;
                    
                }
                
            }

        }
        if (slow)
        {
            slowTimer -= Time.deltaTime;
        }
        if (slowTimer <= 0)
        {
            slowTimer = 3;
            slow = false;
            Destroy(hitSalivaObj);
            isGreenHit = false;
        }
        if (slowTimer > 0 && slowTimer < 3 && slow)
        {
            speed = PlayerPrefs.GetFloat(SlowSpeedKey)/SalivaShooting.slowRateGlobal;
        }
        if (stun)
        {
            stunTimer -= Time.deltaTime;
            animator.SetBool("isShocking", true);
        }
        if (stunTimer <= 0)
        {
            stunTimer = 0.4f;
            stun = false;
            Destroy(hitElectricObj);
            isElectricHit = false;
            animator.SetBool("isShocking", false);
        } 
        if (stunTimer > 0 && stunTimer < 0.4f && stun)
        {
            speed = 0;
            animator.SetBool("isWalking", false);
        }
        if(!slow && !stun && !slowPlatform)
        {
            speed = PlayerPrefs.GetFloat(NormalSpeedKey);
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
        if(hitSalivaObj != null)
        {
            hitSalivaObj.transform.position = new Vector3(-0.3f, Camera.main.transform.position.y, 4);
        }
        if (hitElectricObj != null)
        {
            hitElectricObj.transform.position = new Vector3(-0.2f, Camera.main.transform.position.y, 4);
        }

        if (!IsGrounded())
        {
            animator.SetBool("isWalking", false);
        }
        if (isMoving)
        {
            if (IsGrounded())
            {
                rb.gravityScale = 1f;
                if (direction.x == -1 && animator.GetBool("isShocking")==false)
                {
                    animator.SetBool("isWalking", true);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (direction.x == 1 && animator.GetBool("isShocking") == false)
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

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("salivaBullet"))
        {
            slow = true;
            if (isGreenHit == false) 
            {
                hitSalivaObj = Instantiate(hitSaliva, new Vector3(-0.3f, Camera.main.transform.position.y, 4), Quaternion.identity);
                isGreenHit = true;
            }
            
        }
        if (collision.gameObject.CompareTag("electricBullet"))
        {
            if (isElectricHit == false)
            {
                hitElectricObj = Instantiate(hitElectric, new Vector3(-0.3f, Camera.main.transform.position.y, 4), Quaternion.identity);
                isElectricHit = true;
            }
            
            stun = true;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftSlow") || collision.gameObject.CompareTag("RightSlow") || collision.gameObject.CompareTag("MidSlow"))
        {
            slowPlatform = true;
            if (isGreenHit == false)
            {
                hitSalivaObj = Instantiate(hitSaliva, new Vector3(-0.3f, Camera.main.transform.position.y, 4), Quaternion.identity);
                isGreenHit = true;
            }
        }
    }

}


