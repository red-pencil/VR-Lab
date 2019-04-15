﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeCameraController : MonoBehaviour
{
    private Rigidbody rb;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;


    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    Transform parentTrans;


    void Start()
    {
        rb = GetComponentInParent<Rigidbody>(); 

        parentTrans = this.transform.parent;

        //if (rb)
        // rb.freezeRotation = true;

        
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
/*
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        h = Mathf.Clamp (h, minimumX, maximumX);
        v = Mathf.Clamp (v, minimumY, maximumY);

        Debug.Log("h:" + h + "v:" + v);

        transform.Rotate(v, h, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.transform.localRotation = Quaternion.identity;

*/
        if (Input.GetKeyDown(KeyCode.Space))
            originalRotation = rb.transform.localRotation;

        
    if (Input.GetMouseButton(0))
    {   
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
    }
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
        //transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        transform.localRotation = originalRotation * yQuaternion;

        //parentTrans.rotation = rb.transform.rotation * xQuaternion;
        parentTrans.rotation = xQuaternion;


    }
}
