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
    private Vector2 startTouchpos, endTouchpos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5 && IsGrounded())
            {
                rb.velocity = new Vector2(3, 0);
                animator.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            else if(touchPosition.x < Screen.width * 0.5 && IsGrounded())
            {
                rb.velocity = new Vector2(-3, 0);
                animator.SetBool("isWalking", true);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchpos = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchpos = Input.GetTouch(0).position;
                if (endTouchpos.y >= startTouchpos.y +4  && IsGrounded())
                {
                    rb.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}