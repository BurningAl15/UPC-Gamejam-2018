using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    protected int health;

    public GameObject dieParticles;
    public GameObject deathKitten;
    public int ID;

    private void Awake()
    {
        ID = 0;
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            if (dieParticles!=null)
                Instantiate(dieParticles, transform.position, transform.rotation);
            if (deathKitten != null) { 
                GameObject kitten = Instantiate(deathKitten, transform.position, transform.rotation);
            }

        }

        MusicManager.instance.PlayHurt();
    }

    public int GetHealth()
    {
        if(health<=0 && ID==1)
            GameManager.instance.AddCount();

        return health;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            if (dieParticles != null)
                Instantiate(dieParticles, transform.position, transform.rotation);

            collision.GetComponent<PlayerBehaviour>().Damage();
            if (collision.GetComponent<PlayerBehaviour>().GetHealth()<=0)
            {
                collision.GetComponent<PlayerBehaviour>().Die();
            }
            Destroy(this.gameObject);
        }
    }
}
