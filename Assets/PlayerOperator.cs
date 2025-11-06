using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOperator : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    float jumpSpeed = 15;
    float lotationMax = 45;
    float lotationDeg = 0.3f;
    float lotation_x = 0, lotation_z = 0;
    bool IsGrand;
    int deadLine = -5;
    void Start()
    {
     rigidbody = GetComponent<Rigidbody>();
        transform.LookAt(new Vector3(0,0,0));
        IsGrand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadLine)//—Ž‚¿‚½‚Æ‚«
        {
            transform.position = new Vector3(0, 3, 0);
            rigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Space) && IsGrand)
        {
            rigidbody.velocity = transform.up*jumpSpeed;
            IsGrand = false;
        }

        if (Input.GetKey(KeyCode.A) && lotation_z < lotationMax) //zŽ²‰ñ“]
        {
            lotation_z += lotationDeg;
        }else if (Input.GetKey(KeyCode.D) && lotation_z > -lotationMax)
        {
            lotation_z -= lotationDeg;
        }
        else
        {
            if (lotation_z < 0) lotation_z += lotationDeg / 3;
            if (lotation_z > 0) lotation_z -= lotationDeg / 3;
        }
        if (Input.GetKey(KeyCode.W) && lotation_x < lotationMax) //xŽ²‰ñ“]
        {
            lotation_x += lotationDeg;
        }
        else if (Input.GetKey(KeyCode.S) && lotation_x > -lotationMax)
        {
            lotation_x -= lotationDeg;
        }
        else
        {
            if (lotation_x < 0) lotation_x += lotationDeg / 3;
            if (lotation_x > 0) lotation_x -= lotationDeg / 3;
        }
        transform.rotation = Quaternion.Euler(lotation_x, 0, lotation_z);
    }
    public void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if(go.tag == "float")
        {
            IsGrand = true;
        }
    }
}

