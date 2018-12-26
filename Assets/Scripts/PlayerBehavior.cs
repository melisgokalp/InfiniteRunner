using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject _fog;
    public AudioSource pickup_source;
    public AudioSource obst_source;
    public float horizVel = 0;
    public float vertVel = 0;
    public float depthVel = 4;
    private int count = 0;
    private int lane = 2;
    private bool keycheck = false; 
    public Text countText;
    public Text Lives;
    public Text gameOver;
    public KeyCode KLeft;
    public KeyCode KRight;
    public KeyCode KUp;
    public static float value; 
    private float[] position_x;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        count = 0;
        SetCountText(); 
        Lives.text = "❤❤❤";
        //Array of fixed x-positions for lanes. gives the original x-positions when the lanes are used as indices.
        position_x = new float[]{0, -0.317f, 0.522f, 1.362f};
    }

    void Update()
    {
        //gameOver condition. keys will work only if gameover is not true.
        if (gameOver.text == "GAME OVER")
        {
            rb.velocity = new Vector3(0, 0, 0);
            enabled = false;
        }
        else
        {
            rb.velocity = new Vector3(horizVel, vertVel, depthVel);
            if (Input.GetKeyDown(KLeft) && (lane > 1) && (keycheck == false))
            {
                horizVel = -2;
                lane -= 1;
                keycheck = true;
                StartCoroutine(stopSlide());
            }
            if (Input.GetKeyDown(KRight) && (lane < 3) && (keycheck == false))
            {
                horizVel = 2;
                lane += 1;
                keycheck = true;
                StartCoroutine(stopSlide());
            } 
        }
    }

    IEnumerator stopSlide() {
        //helper method for stopping the sliding motion along x-axis. 
        //repositions the player in case final x-position is incorrect.
        yield return new WaitForSeconds(.4f);
        horizVel = 0;
        keycheck = false;
        rb.transform.position = new Vector3(position_x[lane], rb.transform.position.y, rb.transform.position.z);
    }

    IEnumerator stopSlowdown()
    {
        //helper method for stopping the slowing down after hitting obstacles. 
        yield return new WaitForSeconds(.45f); 
        depthVel = 4;
    }

    void OnTriggerEnter(Collider other)
    {
        //Collision condition if the object is a coin. Plays a sound, updates the score and hides the coin under the platform until it is recycled.
        if (other.gameObject.CompareTag("Collectable") && (gameOver.text != "GAME OVER"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y - 2, other.gameObject.transform.position.z);
            count++;
            pickup_source.GetComponent<AudioSource>().Play();
            SetCountText();
        }
        //Collision condition if the object is an obstacle. Plays a sound, slows down the player and lowers the obstacle.
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - 0.2f, other.gameObject.transform.position.z);
            depthVel = 1.5f; 
            obst_source.GetComponents<AudioSource>()[0].Play();
            obst_source.GetComponents<AudioSource>()[1].Play();
            StartCoroutine(stopSlowdown()); 
            //Removes one heart character from the "lives" string in case of a collision.
            Lives.text = Lives.text.Remove(Lives.text.Length - 1);
        }
    }

    void SetCountText()
    {
        //Updates the score according to count.
        countText.text = "Score: " + (count* 10).ToString(); 
    } 
}