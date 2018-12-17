using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : EnemyHealth {
    public float speed;
    public GameObject bullet;

    public float delay = 1f;
    public const float lag = 0.5f;
    //public float movementDelay = lag;
    private Transform target;

    public int type;
    [SerializeField]
    float upDown = 0;
    int dir=1;
    int[] rightOrLeft = new int[2];
    int wayIndex;
    Rigidbody2D rg;
    private void Start()
    {
        ID = 1;
        target = GameObject.Find("Player").GetComponent<Transform>();
        rg = GetComponent<Rigidbody2D>();
        rightOrLeft[0] = -1;
        rightOrLeft[1] = 1;
        wayIndex = Random.Range(0, 2);
    }

    private void Update()
    {
        upDown = 2*dir;
        transform.Rotate(0f, 0f, Mathf.Lerp(-2,2,upDown)*5);

        rg.velocity = new Vector2(rightOrLeft[wayIndex] * speed * Time.deltaTime, Mathf.Lerp(-2, 2,upDown ));
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            dir *= -1;
            delay = lag;
        }
    }

    //void Behaviour(int type)
    //{
    //    switch(type)
    //    {
    //        case 0:
    //            break;
    //        case 1:
    //            transform.Rotate(0f, 0f, 4f);

    //            rg.velocity = new Vector2(rightOrLeft[wayIndex]*speed * Time.deltaTime, 0);

    //            break;
    //        //case 2://Sinusoidal movement
    //        //    index += Time.deltaTime * 0.3f;
    //        //    float x = amplitudeX * Mathf.Cos(omegaX * index);
    //        //    float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
    //        //    transform.localPosition = new Vector3(x, y, 0);

    //        //    break;
    //    }
    //}

    //void Shoot()
    //{
    //    Instantiate(bullet, new Vector2(transform.position.x + 1f,
    //transform.position.y), Quaternion.identity);

    //    Instantiate(bullet, new Vector2(transform.position.x - 1f,
    //        transform.position.y), Quaternion.identity);
    //}

    private void OnBecameInvisible()
    {
        switch(wayIndex)
        {
            case 0:
                transform.position = new Vector2(14f, transform.position.y+Random.Range(-2f,2f));
                break;
            case 1:
                transform.position = new Vector2(-13.7f,transform.position.y + Random.Range(-2f, 2f));
                break;
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
        }
    }
}
