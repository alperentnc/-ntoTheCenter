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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrolling = gameObject.GetComponent<EnemyPatrolling>();
    }

    
    void Update()
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < fireDistance)
        {
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
        }
        
        
    }

    void Shoot() {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
