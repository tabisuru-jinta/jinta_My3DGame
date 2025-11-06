using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoroller : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5.0f;
    float range_y = 8;
    float range_x = 16;
    void Start()
    {
        Debug.Log("Start");
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }

        Vector3 pos = transform.position;
        if(transform.position.x < -range_x)
        {
            pos.x = -range_x;
        }else if(transform.position.x > range_x)
        {
            pos.x = range_x;
        }
        if (transform.position.y < -range_y)
        {
            pos.y = -range_y;
        }
        else if (transform.position.y > range_y)
        {
            pos.y = range_y;
        }
        transform.position = pos;

        Vector3 direction = new Vector3(x, y, 0);
        GetComponent<Rigidbody2D>().velocity = direction*speed;
    }
}
