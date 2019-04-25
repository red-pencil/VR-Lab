using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayerController : MonoBehaviour
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

    public float oneSideRange = 60;

    edgeCheck edgeState;

    Quaternion orginalTrans;
    private float timeCount = 0.0f;

    void Start()
    {
        gbCamera = Camera.main.gameObject;
        gbBody = gameObject.transform.Find("DummyBody").gameObject;
        gbHead = gameObject.transform.Find("DummyHead").gameObject;

        orginalTrans = transform.localRotation;

        edgeState = GetComponentInChildren<edgeCheck>();
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
        /*
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
        /*
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
        */

        //Debug.DrawRay(transform.position, gbBody.transform.forward, Color.green);
        //Debug.DrawRay(transform.position, gbCamera.transform.forward, Color.red);

        // collider method

        gbHead.transform.localRotation = Quaternion.Euler(0.0f, gbCamera.transform.localRotation.eulerAngles.y, 0.0f);

        float diff = Vector3.Angle(gbHead.transform.forward, gbBody.transform.forward) - oneSideRange;

        // not consider tilt// float diff = Vector3.Angle(gbCamera.transform.forward, gbBody.transform.forward) - oneSideRange;
        //mayber > 180 float diff2 = Mathf.Abs(gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.rotation.eulerAngles.y) - oneSideRange;
        // float diff2 = Quaternion.Angle(gbCamera.transform.rotation, gbBody.transform.rotation) - oneSideRange;
        // Debug.Log("diff=" + diff + "diff2=" + diff2);

        gbBody.transform.localRotation *= ((edgeState._leftEdge) ? Quaternion.AngleAxis(diff, Vector3.down) : Quaternion.identity);
        //Transform temp = gbBody.transform.Find("leftEdge");
       // Debug.DrawRay(temp.position, temp.forward * 10);
        //gbBody.transform.rotation *= ((edgeState._leftEdge) ? Quaternion.Slerp(temp.rotation, gbHead.transform.rotation, timeCount): Quaternion.identity);
        //timeCount = timeCount + Time.deltaTime;
        gbBody.transform.localRotation *= ((edgeState._rightEdge) ? Quaternion.AngleAxis(diff, Vector3.up) : Quaternion.identity);



    }
}
