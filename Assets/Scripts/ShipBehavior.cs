using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ShipBehavior : MonoBehaviour {
    public Text gameOver;
    public GameObject ball;
    public GameObject _fog;
    private Rigidbody ship;
    public float x_vel = 1.2f;
    private bool boatswitch = true;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
        if (ship.transform.position.x < 0)
        {
            x_vel = -x_vel;
        }
        ship.velocity = new Vector3(x_vel, 0, 2);
        ship.transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }

    void Update()
    {
        //gameOver condition
        if (gameOver.text == "GAME OVER")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            x_vel = 0;
            enabled = false;
        }
        //changes the direction of vertical velocity, if the boats are too farther away. The boatswitch prevents glitching and ensures constant movement.
        if ((boatswitch == true)&&(ship.transform.position.x < -80f || ship.transform.position.x > 40f))
        {
            x_vel = -x_vel;
            boatswitch = false;
        } 
        //changes the direction of vertical velocity, if the boats are too close to the platform.
        if (boatswitch == false && ball.GetComponent<Rigidbody>().position.x > ship.position.x && ball.GetComponent<Rigidbody>().position.x - ship.position.x < 20){
            x_vel = -x_vel;
            boatswitch = true;
        }
        //changes the direction of vertical velocity, if the boats are too close to the platform.
        if (boatswitch == false && ball.GetComponent<Rigidbody>().position.x < ship.position.x && ship.position.x - ball.GetComponent<Rigidbody>().position.x < 20)
        {
            x_vel = -x_vel;
            boatswitch = true;
        }
        //repositions the boats farther along the z-axis if they are 25 units behind the player along z-axis.
        if ((ball.GetComponent<Rigidbody>().position.z - ship.position.z) > 25)
        { 
            if(ship.transform.position.x > 0){
                ship.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, (ship.transform.position.z + 200));
            }else{
                ship.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, (ship.transform.position.z + 200));
            }
        }
    ship.velocity = new Vector3(x_vel, 0, 2);
    } 
}