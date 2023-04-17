using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector2(transform.position.x,cam.position.y);
    }
}
