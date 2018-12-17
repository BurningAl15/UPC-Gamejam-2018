using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBasic4Behaviour : EnemyHealth
{
    private Transform target;
    public GameObject bullet;
    public GameObject bulletdown;


    public bool isUp = false;
    public float delay = 1f;
    public const float lag = 0.5f;


    // Use this for initialization
    void Start () {
   
        //  target = FindObjectOfType<PlayerBehaviour>().transform;
        target = GameObject.Find("Player").GetComponent<Transform>();     ItisUp();
	}
     
   public  float amplitudeX = 10.0f;
   public  float amplitudeY = 5.0f;
   public  float omegaX = 1.0f;
   public  float omegaY = 5.0f;
   public  float index;


    public void Update()
    {
        index += Time.deltaTime*0.3f;
        float x = amplitudeX * Mathf.Cos(omegaX * index);
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(x, y, 0);

        Delay();
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
