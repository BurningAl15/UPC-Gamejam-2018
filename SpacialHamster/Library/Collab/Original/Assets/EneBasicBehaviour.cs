﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBasicBehaviour : EnemyHealth
{

    public float speed;
    private Transform target;


	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
