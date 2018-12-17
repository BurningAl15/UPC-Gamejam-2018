using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public List<GameObject> obstacles = new List<GameObject>();

    public float startingTime, delay;

    [SerializeField]
    int index;
    int quantity;
    // Use this for initialization
    void Start()
    {
        index = 0;
        quantity = Random.Range(2, 5);
        Instantiate(obstacles[index], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            index = 0;
            switch(quantity)
            {
                //case 1:
                //    Instantiate(obstacles[index], transform.position, transform.rotation);
                //    break;
                case 2:
                    Instantiate(obstacles[index], new Vector3(transform.position.x-2, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x+2, transform.position.y, transform.position.z), transform.rotation);
                    break;
                case 3:
                    Instantiate(obstacles[index], new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
                    break;
                case 4:
                    Instantiate(obstacles[index], new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x-1.5f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
                    break;
                case 5:
                    Instantiate(obstacles[index], new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(obstacles[index], transform.position, transform.rotation);
                    break;

            }
            quantity = Random.Range(0, 5);
            transform.position = new Vector2(Random.Range(-16f,16f), 8.2f);
            delay = startingTime;
        }

    }
}
