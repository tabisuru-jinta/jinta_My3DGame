using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Asretic2Operatop : MonoBehaviour
{
    // Start is called before the first frame update
    public float amp = 45;
    public float cycle = 1;
    float w;
    void Start()
    {
        w = cycle * 2 * (float)Math.PI;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(amp * (float)Math.Sin(w * Time.time), 0, 0);
    }
}
