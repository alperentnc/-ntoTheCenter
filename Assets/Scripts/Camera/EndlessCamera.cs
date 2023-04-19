using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCamera : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    GameObject target;
    public Transform upper;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target.transform.position.y <= upper.transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.transform.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}


