using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDown : MonoBehaviour {
    Rigidbody2D rg;
    public float speed;

    void Start () {
        rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, 15f);
        rg.velocity = new Vector2(0f, speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
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
