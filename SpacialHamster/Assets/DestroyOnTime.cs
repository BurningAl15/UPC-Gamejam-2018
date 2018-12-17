using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    public float time;
	
	void Update () {
        Destroy(gameObject, time);
	}
}
