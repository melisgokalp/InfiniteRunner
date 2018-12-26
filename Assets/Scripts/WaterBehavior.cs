using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WaterBehavior : MonoBehaviour {
    public Text gameOver;

	void Start () {
        //water moves in constant speed
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
	}
	
	void Update () {
        //gameOver condition -> Water stops moving.
        if (gameOver.text == "GAME OVER"){
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            enabled = false;
        }
	}
}
