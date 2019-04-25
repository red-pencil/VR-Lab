using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyClamp : MonoBehaviour
{
    GameObject gbCamera, gbHead, gbBody;
    public float leftLimit = 60.0f, rightLimit = 60.0f;


    void Start()
    {
        gbCamera = Camera.main.gameObject;
        gbBody = gameObject.transform.Find("DummyBody").gameObject;
        gbHead = gameObject.transform.Find("DummyHead").gameObject;
    }


    void Update()
    {
        
        gbHead.transform.rotation = Quaternion.Euler(0.0f, gbCamera.transform.eulerAngles.y, 0.0f); // why 180?
        //gbHead.transform.localEulerAngles = new Vector3(0.0f, gbCamera.transform.eulerAngles.y + 180, 0.0f);

        
        float headY = gbCamera.transform.eulerAngles.y;
        float bodyY = gbBody.transform.eulerAngles.y;
        Debug.Log("headY: " + headY + "bodyY: " + bodyY);

        if (Mathf.Abs(headY - bodyY) > 180)
        {
            headY = headY > 180 ? headY - 360 : headY;
            bodyY = bodyY > 180 ? bodyY - 360 : bodyY;

        }

        float specialY = Mathf.Clamp(bodyY, headY - rightLimit, headY + leftLimit);

        gbBody.transform.rotation = Quaternion.Euler(0.0f, specialY, 0.0f);

    

    }
}
