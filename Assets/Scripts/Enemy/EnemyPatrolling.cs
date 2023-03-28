using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed;
    private float leftBound;
    private float rightBound;
    private Transform platformTransform;
    EnemyShooting enemyShooting;

    private float direction = 1.0f;

    private void Start()
    {
        float platformHalfWidth = platformTransform.localScale.x*2;
        leftBound = platformTransform.position.x - platformHalfWidth;
        rightBound = platformTransform.position.x + platformHalfWidth;
        enemyShooting = gameObject.GetComponent<EnemyShooting>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            platformTransform = collision.gameObject.transform;
            float platformHalfWidth = collision.gameObject.transform.localScale.x*2;
            leftBound = collision.gameObject.transform.position.x - platformHalfWidth;
            rightBound = collision.gameObject.transform.position.x + platformHalfWidth;
        }
    }
    public void Patroll()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        if (transform.position.x > rightBound)
        {
            direction = -1.0f;
        }
        else if (transform.position.x < leftBound)
        {
            direction = 1.0f;
        }
    }
}