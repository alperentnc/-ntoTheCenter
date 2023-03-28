using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosChanger : MonoBehaviour
{
    private ViewportHandler viewport;
    

    void Start()
    {
        viewport = gameObject.GetComponent<ViewportHandler>();

        if (Screen.height/ Screen.width >=1.61)
        {
            transform.position = new Vector3(transform.position.x, 1.6f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 3.1f, transform.position.z);
        }
    }

    
    void Update()
    {
        
    }
}
