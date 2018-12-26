using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FogBehav : MonoBehaviour {
    public Text gameOver;

    void Start () {
        //Moves along the platform in constant speed
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
    }

	
	// Update is called once per frame
	void Update () {
        //gameOver conditions -> the fog stops moving
        if (gameOver.text == "GAME OVER")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
