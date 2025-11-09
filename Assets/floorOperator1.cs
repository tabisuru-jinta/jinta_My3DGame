using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class floatOperator1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 origin;
    public float cycle = 1f; // ˆê•b‚Ì‰ñ“]”
    public float amp = 3f; //U•
    public Vector3 moveVec = Vector3.up;
    float w; //ƒ‰ƒWƒAƒ“üŠú
    void Start()
    {
        origin = transform.position;
        moveVec.Normalize();
        w = cycle * 2 * (float)Math.PI;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin + amp * moveVec * (float)Math.Sin(w * Time.time);
    }
}
