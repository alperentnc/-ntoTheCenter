using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    [SerializeField] float upper, lower;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.y >= lower && target.transform.position.y <= upper)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}
