using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOperator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 offset = new Vector3(0, 10, -18);
    Vector3 angle = new Vector3(30, 0, 0);
    int follow_height = 5;
    void Start()
    {
        player = GameObject.Find("Player");
        transform.rotation = Quaternion.Euler(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > follow_height)
        {
            transform.position = offset + new Vector3(player.transform.position.x, player.transform.position.y-follow_height, 0);
        }
        else
        {
            transform.position = offset + new Vector3(player.transform.position.x, 0, 0);
        }
            
    }
}
