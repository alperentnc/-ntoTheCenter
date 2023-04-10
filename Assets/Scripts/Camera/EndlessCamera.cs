using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCamera : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public Transform upper;
    void Start()
    {

    }

    void Update()
    {
        if (target.transform.position.y <= upper.transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}


