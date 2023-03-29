using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletFrequency;
    private float timer;
    private GameObject player;
    public float fireDistance;
    EnemyPatrolling enemyPatrolling;
    public Animator animator;
    float yDifferance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrolling = gameObject.GetComponent<EnemyPatrolling>();
        animator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);

        yDifferance = player.transform.position.y - transform.position.y;


        if (distance < fireDistance && System.Math.Abs(yDifferance) <= 1.5f)
        {
            animator.SetBool("isShooting", true);
            if (transform.position.x<=player.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                transform.GetChild(0).localPosition = new Vector3(0.4f, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                transform.GetChild(0).localPosition = new Vector3(-0.4f, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
            }
            timer += Time.deltaTime;
            if (timer > bulletFrequency)
            {
                timer = 0;
                Shoot();
            }
        }
        else
        {
            enemyPatrolling.Patroll();
            animator.SetBool("isShooting", false);
        }
        
        
    }

    void Shoot() {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }

}
