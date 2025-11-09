using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOperator : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;
    float jumpSpeed = 15;
    float lotationMax = 45;
    float lotationDeg = 0.6f;
    float lotation_x = 0, lotation_z = 0;
    bool IsGrand;
    int deadLine = -5;
    const float jumpChargeTime = 0.7f;
    float charge = 0;
    public Vector3 SavePoint = new Vector3(105, 11, 0);
    GameObject leg;
    GameObject head;
    float legLength;
    float headHeight;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.LookAt(new Vector3(0,0,0));
        IsGrand = false;
        leg = GameObject.Find("leg");
        head = GameObject.Find("head");
        transform.position = SavePoint;
        legLength = leg.transform.localScale.y;
        headHeight = head.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //leg.transform.localScale =  new Vector3(0.2f, 2 - (charge / jumpChargeTime)*1.2f,0.2f);
        //leg.transform.localPosition = new Vector3(0, leg.transform.localScale.y/2, 0);
        head.transform.localPosition = new Vector3(0, headHeight - (charge / jumpChargeTime) * 0.7f, 0);

        if (transform.position.y < deadLine)//—Ž‚¿‚½‚Æ‚«
        {
            transform.position = SavePoint;
            rigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (charge < jumpChargeTime) charge += Time.deltaTime;
        }
        else if(charge > 0 )
        {
            if (IsGrand)
            {
                rigidbody.velocity = transform.up * jumpSpeed * charge / jumpChargeTime;
                IsGrand = false;
            }
            charge = 0;
        }

        if (Input.GetKey(KeyCode.A) && lotation_z < lotationMax) //zŽ²‰ñ“]
        {
            lotation_z += lotationDeg;
        }
        else if (Input.GetKey(KeyCode.D) && lotation_z > -lotationMax)
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
        if(go.tag == "floor" && collision.contacts[0].normal == Vector3.up)
        {
            IsGrand = true;
            //Debug.Log("Grand!!");
            if(transform.parent == null)
            {
                GameObject emptyObj = new GameObject();
                emptyObj.transform.parent = go.transform;
                transform.parent = emptyObj.transform;
                //Debug.Log("parent!!");
            }
        }
        if(go.tag == "Goal")
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if(go.tag == "SavePoint")
        {
            Debug.Log("Save!!");
            SavePoint = go.transform.position;
            Destroy(go);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        GameObject go = collision.gameObject;
        //if (go.tag == "float")
        //{
        //    IsGrand = false;
        //}
        //Debug.Log("exit!!");
        if (transform.parent != null && go.tag == "floor")
        {
            transform.parent = null;
        }
    }

}

