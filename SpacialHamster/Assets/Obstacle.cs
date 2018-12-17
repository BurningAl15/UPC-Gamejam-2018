using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    //public int resistance;
    public GameObject tail, explosion;
    Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        GameObject son= Instantiate(tail, transform.position, tail.transform.rotation);
        son.transform.parent = this.gameObject.transform;
        transform.localScale = new Vector3(Random.Range(0.75f, 2f), Random.Range(0.75f, 2f), Random.Range(0.5f, 1.5f));
    }
	
	// Update is called once per frame
	void Update () {
        rgb.velocity =new Vector2(Random.Range(-1f,1f),-1f) * speed;
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerHealth>().Damage();
            if (collision.GetComponent<PlayerHealth>().GetHealth()<=0)
            {
                collision.GetComponent<PlayerBehaviour>().Die();
            }
            Destroy(this.gameObject);
        }
    }
}
