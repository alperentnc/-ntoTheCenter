using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer, animTimer;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Update()
    {
        animTimer += Time.deltaTime;
        //if (animTimer >= 0.3f)
        //{
        //    animator.SetBool("isStop", true);
        //}
        //timer += Time.deltaTime;
        //if (timer > 5)
        //{
        //    Destroy(gameObject);
        //}
        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= 5;
            //Destroy(gameObject);
        }
        //else if (collision.gameObject.CompareTag("Platform"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
