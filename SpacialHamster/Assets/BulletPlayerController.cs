using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerController : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }



}
