using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCam;
    void Start()
    {
        scaleChanger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void scaleChanger()
    {
        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);
        float srcHeight = Screen.height;
        float srcWidth = Screen.width;
        float Device_Screen_Aspect = srcWidth / srcHeight;
        mainCam.aspect = Device_Screen_Aspect;
        float camHeight = 100 * mainCam.orthographicSize * 2;
        float camWidth = camHeight * Device_Screen_Aspect;
        SpriteRenderer Renderer = gameObject.GetComponent<SpriteRenderer>();
        float scObjH = Renderer.sprite.rect.height;
        float scObjW = Renderer.sprite.rect.width;
        float calculateHeight = camHeight / scObjH;
        float calculateWidth = camWidth / scObjW;
        transform.transform.localScale = new Vector3(calculateWidth, calculateHeight, 1);
    }
}
