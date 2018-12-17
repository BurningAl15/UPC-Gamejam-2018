using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemySpawner : MonoBehaviour {
    [SerializeField]
    bool checkStep,otherChecker;

    public float speed;

    public float delay,startingDelay;

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    GameObject enemy;

    int phase;

	// Use this for initialization
	void Start () {
        checkStep = false;
        startingDelay = delay;
        phase = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(!otherChecker)
            delay -= Time.deltaTime;
        if (delay<=0 && otherChecker)
        {
            checkStep = true;
            delay = startingDelay;
        }
        
        if(checkStep)
        {
            //CallEnemy(enemies[phase]);
            CallEnemy(enemy);
        }

        if(GameManager.instance.GetCounter()==phase)
        {
            otherChecker = true;
        }
        else
        {
            otherChecker = false;
        }
	}

    void CallEnemy(GameObject enemy)
    {
        switch(phase)
        {
            case 0:
            case 1:
            case 2:
                Instantiate(enemy, new Vector3(transform.position.x+9.7f, transform.position.y + 2f, transform.position.z), transform.rotation);
                Instantiate(enemy, new Vector3(transform.position.x-9.7f, transform.position.y + 2f, transform.position.z), transform.rotation);
                break;                                             
            default:                                               
                Instantiate(enemy, new Vector3(transform.position.x+9.7f, transform.position.y+2f, transform.position.z), transform.rotation);
                Instantiate(enemy, new Vector3(transform.position.x-9.7f, transform.position.y+2f, transform.position.z), transform.rotation);
                break;
        }
        phase++;
        checkStep = false;
    }
}
