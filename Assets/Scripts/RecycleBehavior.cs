using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBehavior : MonoBehaviour {
    public GameObject ball;
    public GameObject _fog;
    private Rigidbody platform;

    // Use this for initialization
    void Start()
    {
        platform = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the elements further along z-axis if the distance between the element and the player is larger than a certain number.
        if ((ball.GetComponent<Rigidbody>().position.z - platform.position.z) > 9)
        {
            platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, (platform.transform.position.z + 60));
        }
        if (platform.tag == "Collectable" && ((ball.GetComponent<Rigidbody>().position.z - platform.position.z) > 3))
        {
            Recycle(platform.gameObject);
        }
        if (platform.tag == "Obstacle" && ((ball.GetComponent<Rigidbody>().position.z - platform.position.z) > 3))
        {
            Recycle(platform.gameObject);
        }
    }

    void Recycle(GameObject obj)
    {
        //helper method that moves elements to a new z-position 0-10 units ahead the fog.
        float new_z = _fog.GetComponent<Rigidbody>().transform.position.z;
        new_z = new_z + (10 * UnityEngine.Random.value);
        obj.gameObject.transform.position =
               new Vector3(obj.gameObject.transform.position.x, _fog.transform.position.y, new_z);
    }
}
