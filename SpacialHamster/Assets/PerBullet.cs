using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerBullet : EnemyHealth {

    public GameObject particle;

    Transform target;
    public float speed;

    public float sx;
    public float sy;


    Color color;
   public float R;
   public float G  ;

    // Use this for initialization
    void Start()
    {
        G = Random.Range(0.25f, 0.75f);
        R = Random.Range(0.25f,0.75f);

        color = new Color(R,G,0f);

        this.gameObject.GetComponent<SpriteRenderer>().color = color;


        target = GameObject.Find("Player").GetComponent<Transform>();

        float Disx = target.transform.position.x - transform.position.x;
        float Disy = target.transform.position.y - transform.position.y;

        float angle = Mathf.Atan2(Disy, Disx);
        //Debug.Log(angle);

        sx = Mathf.Cos(angle) * speed;
        sy = Mathf.Sin(angle) * speed;
    }
    // Update is called once per frame
    void Update () {

        Disparo();
        Destroy();
        if(health<=0)
        {

        }
    }
    void Disparo()
    {
        transform.position = new Vector2(transform.position.x + sx * Time.deltaTime,
            transform.position.y + sy * Time.deltaTime);
    }


    void Destroy()
    {
        if (transform.position.y >= 7.5f || transform.position.y <= -7.5f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x >= 10f ||transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(particle, transform.position,Quaternion.Euler(0,0,135)  );
            collision.GetComponent<PlayerHealth>().Damage();
            if (collision.GetComponent<PlayerHealth>().GetHealth() <= 0)
            {
                collision.GetComponent<PlayerBehaviour>().Die();
            }

            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Untagged")
        {
            Instantiate(particle, transform.position, Quaternion.Euler(0, 0, 135));
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Enemy")
        {
        } 

    }

}
