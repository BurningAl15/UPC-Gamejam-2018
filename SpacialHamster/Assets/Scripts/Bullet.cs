using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rgb;

    public float speed;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        rgb.velocity = new Vector2(0f,speed*Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            if (collision.GetComponent<EnemyHealth>().GetHealth()<=0)
            {
                Destroy(collision.gameObject);
                MusicManager.instance.PlayExplosion();
            }
            else
            {
                collision.GetComponent<EnemyHealth>().Damage();
            }
            Destroy(gameObject);
        }

        if (collision.tag.Equals("Obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.tag.Equals("BossBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.tag.Equals("Boss"))
        {
            if (collision.GetComponent<EnemyHealth>().GetHealth() <= 0)
            {
                collision.GetComponent<SpriteRenderer>().enabled = false;
                collision.GetComponent<Collider2D>().enabled = false;
                collision.GetComponent<BossController>().deathboss.SetActive(true);
                MusicManager.instance.PlayExplosion();
            }
            else
            {
                collision.GetComponent<SpriteRenderer>().enabled = false;
                collision.GetComponent<EnemyHealth>().Damage();
            }
            Destroy(gameObject);
        }
    }

}
