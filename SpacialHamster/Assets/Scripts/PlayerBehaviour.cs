using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : PlayerHealth {

    public float speed;
    public int shootState;
    Rigidbody2D rgb;
    public GameObject bullet;

    public GameObject deathHamster;

    public GameObject killedMenu;

    [SerializeField]
    float maxX, minX, maxY, minY;

    [SerializeField]
    float ejectableDistance;
    Vector3 ejectablePlace;

    public float delay, startingDelay;

    public bool isAlive;
   
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        isAlive = true;
        delay = startingDelay;
        deathHamster.SetActive(false);
        killedMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if(isAlive)
        { 
            Movement();
            Attack();
        }
        else
        {
            InvokeRepeating("DestroyingShip", 0.5f, 0f);
            deathHamster.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            delay -= Time.deltaTime;
            killedMenu.SetActive(true);
            if(delay<=0)
            {
                CancelInvoke("DestroyingShip");
                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }

    void DestroyingShip()
    {
        Instantiate(dieParticles, transform.position, transform.rotation);
    }

    void Movement()
    {
        rgb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))*speed;
        //if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(movementParticles, transform.position, transform.rotation);
        //}
        transform.position = new Vector3(Mathf.Clamp(rgb.position.x,minX,maxX),Mathf.Clamp(rgb.position.y,minY,maxY));
    }

    void Attack()
    {
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
     
    }

    void Shot()
    {
        Instantiate(bullet, new Vector2(transform.position.x + 1f,
            transform.position.y+0.5f), Quaternion.identity);

        Instantiate(bullet, new Vector2(transform.position.x - 1f,
            transform.position.y + 0.5f), Quaternion.identity);

        MusicManager.instance.PlayShoot();
    }

    void Eject()
    {
        //line.SetPosition(1, transform.position+ejectablePlace);
        Debug.Log("Ejecting");
    }

    public void Die()
    {
        isAlive = false;
        MusicManager.instance.PlayExplosion();
    }
}
