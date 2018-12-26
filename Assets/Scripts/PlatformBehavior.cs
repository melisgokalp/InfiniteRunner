using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject _fog;
    private Rigidbody platform;

    void Start()
    {
        platform = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Moves the platform elements forward along z-axis if the distance between the platform and the player is larger than 9 
        if ((player.GetComponent<Rigidbody>().position.z - platform.position.z) > 9)
        { 
            platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, (platform.transform.position.z + 60));
        }
        //Moves the collectable coins and obstacles  forward along z-axis if the distance between the platform and the player is larger than 3 
        if(platform.tag == "Collectable" && ((player.GetComponent<Rigidbody>().position.z - platform.position.z) > 3)){
            Recycle(platform.gameObject);
        }
        if (platform.tag == "Obstacle" && ((player.GetComponent<Rigidbody>().position.z - platform.position.z) > 3))
        {
            Recycle(platform.gameObject);
        }
    }

    void Recycle(GameObject obj)
    //Helper method for moving the elements forward. Places them 0 to 10 units ahead of the fog element.
    {
        float new_z = _fog.GetComponent<Rigidbody>().transform.position.z;
        new_z = new_z + (10 * UnityEngine.Random.value);
        obj.gameObject.transform.position =
               new Vector3(obj.gameObject.transform.position.x, _fog.GetComponent<Rigidbody>().transform.position.y, new_z);
    }
}
