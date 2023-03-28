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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrolling = gameObject.GetComponent<EnemyPatrolling>();
        animator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < fireDistance)
        {
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
        animator.SetBool("isShooting", true);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }

}
