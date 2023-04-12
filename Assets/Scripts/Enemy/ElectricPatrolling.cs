using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPatrolling : MonoBehaviour
{
    public float speed;
    private float leftBound;
    private float rightBound;
    private Transform platformTransform;
    EnemyShooting enemyShooting;
    private float platformHalfWidth;

    public float direction = 1.0f;
    private Vector3 scale;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftPlatform" || collision.gameObject.tag == "RightPlatform" || collision.gameObject.tag == "MiddlePlatform")
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
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).localPosition = new Vector3(-1, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);

        }
        else if (transform.position.x < leftBound)
        {
            direction = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(0).localPosition = new Vector3(1, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
        }
        //else
        {
        }
    }
}