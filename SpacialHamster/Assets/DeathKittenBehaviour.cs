using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathKittenBehaviour : MonoBehaviour {
    Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rgb.velocity = new Vector2(0f, 5f);
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
