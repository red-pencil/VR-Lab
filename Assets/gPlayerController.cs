using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gPlayerController : MonoBehaviour
{
    GameObject gbCamera, gbBody, gbHead;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    public float minimumH = -60F;
    public float maximumH = 60F;
    public float rotationV = 0F;
    public float rotationH = 0F;


    Quaternion orginalTrans;

    void Start()
    {
        gbCamera = Camera.main.gameObject;

        gbBody = gameObject.transform.Find("dummyBody").gameObject;
        gbHead = gameObject.transform.Find("playerHead").gameObject;

        orginalTrans = transform.localRotation;
    }


    void Update()
    {
        Quaternion hQu, vQu, hQuHead;



        //rotationV = gbCamera.transform.rotation.eulerAngles.x;
        //rotationH = gbCamera.transform.rotation.eulerAngles.y;

        //rotationH = gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.localRotation.eulerAngles.y;




        /*
        // simple method
        
        rotationH = gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.localRotation.eulerAngles.y;

        hQu = Quaternion.AngleAxis(rotationH, Vector3.up);
        vQu = Quaternion.AngleAxis(rotationV, Vector3.right);

        gbBody.transform.localRotation = gbBody.transform.localRotation * hQu * vQu;
        */

        rotationH = gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.rotation.eulerAngles.y;
        Debug.Log("camera:" + gbCamera.transform.rotation.eulerAngles.y + "body:" + gbBody.transform.rotation.eulerAngles.y);
        hQu = Quaternion.AngleAxis(rotationH, Vector3.up);

        /*
        if (rotationH > 180)
        {
            rotationH = (360 - gbCamera.transform.rotation.eulerAngles.y) - gbBody.transform.rotation.eulerAngles.y;
        } else if (rotationH < -180)
        {

            rotationH = gbCamera.transform.rotation.eulerAngles.y - (360 - gbBody.transform.rotation.eulerAngles.y);
        }
        */

        if (Mathf.Abs(rotationH) > 180)
        {
            rotationH = rotationH > 360 ? rotationH - 360 : 360 - rotationH;

        }


        if ( (rotationH <= 30) && (rotationH >= -30) )
        {
            gbBody.transform.rotation = gbBody.transform.rotation;
        }

        if (rotationH > 30)
        {
            hQu = Quaternion.AngleAxis(rotationH - 30, Vector3.up);
            gbBody.transform.rotation = gbBody.transform.rotation * hQu;
        }

        if (rotationH <-30)
        {
            hQu = Quaternion.AngleAxis(rotationH + 30, Vector3.up);
            gbBody.transform.rotation = gbBody.transform.rotation * hQu;

        }


        // rh <30, not, rH > 30, rotate(rH-30), rH < 30, not


        Debug.DrawRay(transform.position, gbBody.transform.forward, Color.green);
        Debug.DrawRay(transform.position, gbCamera.transform.forward, Color.red);


    }
}
