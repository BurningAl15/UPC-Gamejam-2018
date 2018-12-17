using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBasic3Behaviour : EnemyHealth
{
    public float speed;
    public GameObject bullet;
    public const float lag = 0.5f;
    [SerializeField]
    public float delay=1f;
    private Transform target;
    Rigidbody2D rg;
    private bool isRight = false;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();

        if (transform.position.x >= target.transform.position.x)
        {
            isRight = false;
        }
        else if (transform.position.x < target.transform.position.x)
        {
            isRight = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Delay();
    }
    void Movement()
    {
        if (isRight == true)
        {
            rg.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
        if (isRight == false)
        {
            rg.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }
    }
    void Delay() 
    {  
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Shoot();
            delay = lag;
        }
    }
    void Shoot()
    {
        Instantiate(bullet, new Vector2(transform.position.x + 1f,
            transform.position.y), Quaternion.identity);

        Instantiate(bullet, new Vector2(transform.position.x - 1f,
            transform.position.y), Quaternion.identity);

    }
}
