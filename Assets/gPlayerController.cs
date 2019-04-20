using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gPlayerController : MonoBehaviour
{
    GameObject gbCamera;
    GameObject gbBody;

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

        orginalTrans = transform.localRotation;
    }
    

    void Update()
    {
        Quaternion hQu, vQu;



        //rotationV = gbCamera.transform.rotation.eulerAngles.x;
        //rotationH = gbCamera.transform.rotation.eulerAngles.y;

        //rotationH = gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.localRotation.eulerAngles.y;


        rotationH = gbCamera.transform.rotation.eulerAngles.y - gbBody.transform.localRotation.eulerAngles.y;

        hQu = Quaternion.AngleAxis(rotationH, Vector3.up);
        vQu = Quaternion.AngleAxis(rotationV, Vector3.right);

        gbBody.transform.localRotation = gbBody.transform.localRotation * hQu * vQu;

    }
}
