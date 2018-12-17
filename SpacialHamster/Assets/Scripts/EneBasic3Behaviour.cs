using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBasic3Behaviour : EnemyHealth
{
    public float speed;
    public GameObject bullet;
    public GameObject bulletdown;


    public bool isUp = false;

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
        ItisUp();

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Delay();

        transform.Rotate(0f, 0f, 4f);

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
        if (isUp == true)
        {
            Instantiate(bulletdown, new Vector2(transform.position.x + 1f,
                transform.position.y), Quaternion.identity);

            Instantiate(bulletdown, new Vector2(transform.position.x - 1f,
                transform.position.y), Quaternion.identity);
        }
        if (isUp == false)
        {
            Instantiate(bullet, new Vector2(transform.position.x + 1f,
                transform.position.y), Quaternion.identity);

            Instantiate(bullet, new Vector2(transform.position.x - 1f,
                transform.position.y), Quaternion.identity);
        }


    }

    void ItisUp()
    {
        if (transform.position.y >= target.transform.position.y)
        {
            isUp = true;
        }
        else if (transform.position.y < target.transform.position.y)
        {
            isUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerBehaviour>().Damage();
            if (collision.GetComponent<PlayerBehaviour>().GetHealth() <= 0)
            {
                collision.GetComponent<PlayerBehaviour>().Die();
            }
            Destroy(this.gameObject);
        }
    }



}
