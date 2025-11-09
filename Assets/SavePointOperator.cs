using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointOperator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject floor;
    Vector3 offset;
    void Start()
    {
        offset = new Vector3(0,transform.localScale.y/2 + 1,0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = floor.transform.position + offset;
    }
}
