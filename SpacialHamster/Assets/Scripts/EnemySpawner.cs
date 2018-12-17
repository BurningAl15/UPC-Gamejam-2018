using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();
    public float times=0;

    public GameObject instances;
    public GameObject instances2;
    public GameObject instances3;
    public GameObject instances4;
    public GameObject instances5;
    public GameObject instances6;
    public GameObject mainEnemy;




    public bool Avez=false;
    public bool Bvez =false;

    public bool Cvez = false;
    public bool Dvez = false;

    public bool Evez = false;
    public bool Fvez = false;




    public float startingTime, delay;
    public float startingTime2, delay2;
    public float startingTime3, delay3;
    public float startingTime4, delay4;
    public float startingTime5, delay5;
    public float startingTime6, delay6;





    // Use this for initialization
    void Start () {

//        Instantiate(enemies[index], transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        //   delay -= Time.deltaTime;

        delay -= Time.deltaTime;
        delay2 -= Time.deltaTime;
        delay3 -= Time.deltaTime;
        delay4 -= Time.deltaTime;
        delay5 -= Time.deltaTime;
        delay6 -= Time.deltaTime;
        if (delay<=0 && Avez == false)
        {
            Instantiate(mainEnemy, new Vector2(9.1f,3), transform.rotation);
            Instantiate(instances, transform.position, transform.rotation);
            delay = startingTime;
            Avez = true;
        }

        if (delay2 <= 0 && Bvez == false)
        {
            Instantiate(mainEnemy, new Vector2(-9.1f, 2), transform.rotation);
            Instantiate(instances2, transform.position, transform.rotation);
            delay2 = startingTime2;
            Bvez = true;
        }
        if (delay3 <= 0 && Cvez == false)
        {
            Instantiate(mainEnemy, new Vector2(-9.1f, 2), transform.rotation);
            Instantiate(instances3, transform.position, transform.rotation);
            delay3 = startingTime3;
            Cvez = true;
        }
        if (delay4 <= 0 && Dvez == false)
        {
            Instantiate(mainEnemy, new Vector2(9.1f, 2), transform.rotation);
            Instantiate(instances4, transform.position, transform.rotation);
            delay4 = startingTime4;
            Dvez = true;
        }
        if (delay5 <= 0 && Evez == false)
        {
            Instantiate(mainEnemy, new Vector2(9.1f, 2), transform.rotation);
            Instantiate(instances5, transform.position, transform.rotation);
            delay5 = startingTime5;
            Evez = true;
        }
        if (delay6 <= 0 && Fvez == false)
        {
            Instantiate(mainEnemy, new Vector2(9.1f, 2), transform.rotation);
            Instantiate(instances6, transform.position, transform.rotation);
            delay6 = startingTime6;
            Fvez = true;
        }





    }
}
