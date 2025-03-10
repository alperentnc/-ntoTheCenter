using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    private PlayerController player;
    private PlayerHealth playerHealth;
    public float min,max;
    private float timer, meteorStartTimer;
    public GameObject symbol,meteorPrefab;
    GameObject symbolObj;
    public Camera cam;
    public bool symbolBool=false;
    float symbolTimer;
    Vector3 startPos;

  

    private const string HealthKey = "PlayerHealth";

    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();

        meteorStartTimer = Random.Range(min, max);
        rb = GetComponent<Rigidbody2D>();
        startPos = new Vector2(transform.position.x, transform.position.y);


    }

    // Update is called once per frame
    void Update()
    {
        symbolTimer += Time.deltaTime;
        if (symbolBool == true)
        {
            if (symbolObj != null)
            {
                symbolObj.transform.position = new Vector3(symbolObj.transform.position.x, cam.transform.position.y +4,3);
            }
            
        }
        if (transform.position.y <= cam.transform.position.y - 8)
        {
            Instantiate(meteorPrefab, new Vector3(startPos.x, cam.transform.position.y+15,4), Quaternion.identity);
            timer = 0;
            Destroy(this.gameObject);
        }
        if (PlayerController.meteorStarter == true) 
        {
            timer += Time.deltaTime;
            if (timer>meteorStartTimer)
            {
                rb.velocity = new Vector2(0, -7);
            }
        }
        if (transform.position.y <= cam.transform.position.y + 12 && transform.position.y >= cam.transform.position.y +7 && rb.velocity!=new Vector2(0,0))
        {
            if (symbolBool == false)
            {
                symbolObj =Instantiate(symbol, new Vector3(transform.position.x, cam.transform.position.y + 5, transform.position.z), Quaternion.identity);
                symbolBool = true;
            }
            
        }
        else if (transform.position.y < cam.transform.position.y+7)
        {
            Destroy(symbolObj.gameObject);
            symbolBool = false;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerHealth.health =0;
            PlayerPrefs.SetInt(HealthKey, playerHealth.health);
        }
    }
}
