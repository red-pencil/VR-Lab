using System.Collections;
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

    private Transform parentTrans;
    public bool dragToSee;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();

        parentTrans = this.transform.parent;

        //if (rb)
        // rb.freezeRotation = true;

        originalRotation = transform.localRotation;
        //Debug.Log(originalRotation.eulerAngles);
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

        if ( (!dragToSee) || (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftCommand)) )
        {   
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
        }

        if (Input.GetKeyDown(KeyCode.Space))
         {
             //rotationX = 0;
             rotationY = 0;
         }
        //Debug.Log("X:" + rotationX);
        //Debug.Log("Y:" + rotationY);
        Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
       

         //transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        transform.localRotation = originalRotation * yQuaternion; //this rotation

        //parentTrans.rotation = rb.transform.rotation * xQuaternion;
        parentTrans.rotation = xQuaternion; //parent rotation


    }
}
