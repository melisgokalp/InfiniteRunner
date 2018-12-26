using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBehavior : MonoBehaviour
{
    private float RotateSpeed = 0.1f;
    private float Radius = 6.6f;
    private Vector3 _centre;
    private float _angle;
    private Rigidbody shark;
    public GameObject player;
    public GameObject fog;

    private void Start()
    {
        shark = GetComponent<Rigidbody>();
        _centre = new Vector3(shark.transform.position.x, shark.transform.position.y, shark.transform.position.z);
    }

    private void Update()
    { 
        //Rotates the sharks in a circle 
         _angle += RotateSpeed * Time.deltaTime;
        if(shark.position.x > 0){
            var offset = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * -Radius;
            shark.transform.position = _centre + offset;
         } else{
            var offset2 = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * Radius;
            shark.transform.position = _centre + offset2;
         }
        if ((player.GetComponent<Rigidbody>().position.z - shark.position.z) > 9)
        {
            if (shark.position.x > 0)
            {
                shark.transform.position = new Vector3(shark.transform.position.x, shark.transform.position.y, (fog.transform.position.z + 50));
            }
            else
            {
                shark.transform.position = new Vector3(shark.transform.position.x, shark.transform.position.y, (fog.transform.position.z + 50));
            }
        }
    }
}