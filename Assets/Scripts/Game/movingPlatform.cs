using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 oldpos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldpos = transform.position;
        rb.velocity = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= oldpos.x+1.5f)
        {
            rb.velocity = new Vector2(-1, 0);
            oldpos = transform.position;
        }
        else if (oldpos.x >= transform.position.x + 1.5f)
        {
            rb.velocity = new Vector2(1, 0);
            oldpos = transform.position;
        }
    }
}
