using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  


public class CamBehav : MonoBehaviour {
    public GameObject player;
    private Rigidbody mainCam;
    public Text gameOver;
    public Text EndOption;
    public KeyCode Quit;
    public AudioSource walking_audio;
    public AudioSource gameOver_audio;
    public AudioSource water;

	void Start () {
        mainCam = GetComponent<Rigidbody>();
        //Follows the player in constant speed
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
        gameOver.text = "";
	}
	
	void Update () {
        //gameOver Condition
        if ((mainCam.transform.position.z > 0) && (player.GetComponent<Rigidbody>().position.z - mainCam.position.z < 3.8f)){
            gameOver_audio.GetComponent<AudioSource>().Play();
            walking_audio.GetComponent<AudioSource>().Pause();
            water.GetComponent<AudioSource>().Pause();
            gameOver.text = "GAME OVER";
            EndOption.text = "Press Q to quit";
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0));
            player.GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, -0.3f, 0.1f);
            if (GetComponent<Rigidbody>().transform.position.y < 10){
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                enabled = false;
            }
        }
        if (Input.GetKeyDown(Quit))
        {
            Application.Quit();
            enabled = false;
        }
	}
}
