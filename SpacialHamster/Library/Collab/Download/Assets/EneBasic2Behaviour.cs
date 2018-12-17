using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBasic2Behaviour : MonoBehaviour {

    public float speed;

    private Transform target;
    Rigidbody2D rg;

    private bool isRight = false;




    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();

        if (transform.position.x >= target.transform.position.x)
        {
            isRight = false;
        }
        else if (transform.position.x < target.transform.position.x)
        {
            isRight = true;
        }

    }
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (isRight == true)
        {
            rg.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
        if (isRight == false)
        {
            rg.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }



    }

}
