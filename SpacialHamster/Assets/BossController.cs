using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyHealth {
    public GameObject deathboss;

    public float mov2speed;

    public float saveY;
    public float speedEmpicada;


 enum BOSSTATE { MOVIMIENTO1, ATACANDO,INSTANCIADO,FRENETICO,VIVO,MUERTO}
    BOSSTATE bosstate=BOSSTATE.MOVIMIENTO1;
    BOSSTATE vive = BOSSTATE.VIVO;


    private Transform target;

    public GameObject perbullet;


    public float maxX;
    public float maxY;

    public float NEGAmaxX;
    public float NEGAmaxY;

    public float speed;
    public bool haciaderecha=true;


    public float currenttime;
    public float delay;


    public GameObject Ene1;
    public GameObject Ene2;
    public GameObject Ene3;
    public GameObject Ene4;

    public float delayEstate;
    public float delayEstate2;
    public float delayEstate3;
    public float delayEstate4;


    public bool isInstanciado = false;


    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").GetComponent<Transform>();
        ID = 1;
        saveY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (vive == BOSSTATE.VIVO)
        {
            if (bosstate == BOSSTATE.MOVIMIENTO1 && delayEstate >= 0)
            {
                Movement1();
                delayEstate -= Time.deltaTime;
            }
            if (delayEstate <= 0)
            {
                bosstate = BOSSTATE.ATACANDO;
            }


            if (bosstate == BOSSTATE.ATACANDO && delayEstate2 >= 0)
            {
                Attack();
                Movement1();
                delayEstate2 -= Time.deltaTime;
            }
            if (delayEstate2 <= 0)
            {
                bosstate = BOSSTATE.INSTANCIADO;
            }


            if (bosstate == BOSSTATE.INSTANCIADO && delayEstate3 >= 0)
            {
                Attack();
                Movement1();
                if (isInstanciado == false)
                {
                    Instancias(); isInstanciado = true;
                }
                delayEstate3 -= Time.deltaTime;
            }
            if (delayEstate3 <= 0)
            {
                bosstate = BOSSTATE.FRENETICO;
            }
            if (bosstate == BOSSTATE.FRENETICO && delayEstate4 >= 0)
            {
                Attack2();
                Movimiento2();
            }
            //    delayEstate3 -= Time.deltaTime;
            /* }
             if (delayEstate3 <= 0)
             {
                 bosstate = BOSSTATE.FRENETICO;
             }*/

        }

        //if (vive== BOSSTATE.MUERTO)
        //{
        //    Debug.Log("Muerto");
        //    deathboss.SetActive(true);
        //}



    }

    void Attack()
    {
       
        if (delay<=0)
        {
            GameObject a = GameObject.Find("Player");
            if (a != null)
            {
                CancelInvoke("Shot");
                InvokeRepeating("Shot", 0f, 0.7f);
                delay = currenttime;
            }    
        }
        delay -= Time.deltaTime;
    }
    void Attack2()
    {

        if (delay <= 0)
        {
            GameObject a = GameObject.Find("Player");
            if (a != null)
            {
                CancelInvoke("Shot");
                InvokeRepeating("Shot", 0f, 0.15f);
                delay = currenttime;
            }
        }
        delay -= Time.deltaTime;
    }

    void Shot()
    {
        Instantiate(perbullet, new Vector2(transform.position.x +2f,
            transform.position.y + 0.5f), perbullet.transform.rotation);

        Instantiate(perbullet, new Vector2(transform.position.x - 2f,
            transform.position.y + 0.5f), perbullet.transform.rotation);
    }

    void Movement1()
    {
        if (transform.position.x <= maxX &&haciaderecha==true)
        {
            transform.position = new Vector2(transform.position.x+speed*Time.deltaTime,
                transform.position.y);
        }
        else
        {
            haciaderecha = false;

        }
        if (transform.position.x >= NEGAmaxX && haciaderecha==false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,
                transform.position.y);
        }
        else { haciaderecha = true; }


    }
 

    void Instancias()
    {
        Instantiate(Ene3, new Vector3(12, 4, 0), Quaternion.identity);
        Instantiate(Ene3, new Vector3(14, 4, 0), Quaternion.identity);

        Instantiate(Ene3, new Vector3(15, 4, 0), Quaternion.identity);
        Instantiate(Ene3, new Vector3(18, 4, 0), Quaternion.identity);



        Instantiate(Ene3, new Vector3(-12, 4, 0), Quaternion.identity);
        Instantiate(Ene3, new Vector3(-14, 4, 0), Quaternion.identity);

        Instantiate(Ene3, new Vector3(-15, 4, 0), Quaternion.identity);
        Instantiate(Ene3, new Vector3(-18, 4, 0), Quaternion.identity);
    }

    void Movimiento2()
    {
        if (target.transform.position.x >= transform.position.x)
        {
            transform.position = new Vector2(transform.position.x + mov2speed * Time.deltaTime,
                transform.position.y);
        }
        if (target.transform.position.x <= transform.position.x)
        {
            transform.position = new Vector2(transform.position.x - mov2speed * Time.deltaTime,
                transform.position.y);
        }
    }





}
