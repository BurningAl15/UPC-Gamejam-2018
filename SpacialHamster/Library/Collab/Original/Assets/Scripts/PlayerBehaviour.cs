using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : PlayerHealth {
    public GameObject claw;

    public float speed;
    public int shootState;
    Rigidbody2D rgb;
    public GameObject bullet;

    public GameObject movementParticles;

    [SerializeField]
    float maxX, minX, maxY, minY;

    [SerializeField]
    float ejectableDistance;
    Vector3 ejectablePlace;

    LineRenderer line;
    
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        ejectablePlace = /*Quaternion.Euler(0f, 0f, 15f)**/Vector3.up;
    }
    // Update is called once per frame
    void Update () {
        Movement();
        Attack();

        line.SetPosition(0, transform.position);
        if (health==1)
        {
            Eject();
        }
        else
        {
            line.SetPosition(1, transform.position);
        }
    }
    void Movement()
    {
        rgb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))*speed;
        if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(movementParticles, transform.position, transform.rotation);
        }
        transform.position = new Vector3(Mathf.Clamp(rgb.position.x,minX,maxX),Mathf.Clamp(rgb.position.y,minY,maxY));
    }
    void Attack()
    {
        /* if(Input.GetKeyDown(KeyCode.Space))
         {
             Instantiate(bullet, new Vector2(transform.position.x,transform.position.y+1),Quaternion.identity);
         }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject a = GameObject.Find("Player");
            if (a != null)
            {
                InvokeRepeating("Shot",0,0.3f);

            }
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shot");
        }
        Claw();
    }
    void Shot()
    {
        Instantiate(bullet, new Vector2(transform.position.x + 1f,
            transform.position.y+0.5f), Quaternion.identity);

        Instantiate(bullet, new Vector2(transform.position.x - 1f,
            transform.position.y + 0.5f), Quaternion.identity);
    }

    void Eject()
    {
        //line.SetPosition(1, transform.position+ejectablePlace);
        Debug.DrawLine(transform.position, transform.position + ejectablePlace);
    }

    void Claw()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Instantiate(claw, transform.position, Quaternion.identity);
        }

    }

}
