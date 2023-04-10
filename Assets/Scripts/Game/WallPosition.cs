using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPosition : MonoBehaviour
{
    public GameObject cam;
    void Update()
    {
        gameObject.transform.position = new Vector2(transform.position.x, cam.transform.position.y);
    }
}
