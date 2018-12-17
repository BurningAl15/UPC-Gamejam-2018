using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulling : MonoBehaviour {

    public float limit = 18.27604f;
    public float speed = 5f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Pull();

    }

    void Pull()
    {
        transform.position = new Vector2(0, transform.position.y - Time.deltaTime*speed);
        if (transform.position.y <= -limit)
        {
            transform.position = new Vector2(0,transform.position.y + 2.0f * limit);
        }



    }

}
