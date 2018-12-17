using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUp : MonoBehaviour {
    Rigidbody2D rg;
    public float speed;
    // Use this for initialization
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
}
