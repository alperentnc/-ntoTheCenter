using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRain : MonoBehaviour
{
    public float animTimer;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRaining", false);
    }

    // Update is called once per frame
    void Update()
    {
        animTimer += Time.deltaTime;
        if (animTimer >= 6){

            anim.SetBool("isRaining", true);
        }
    }
}
