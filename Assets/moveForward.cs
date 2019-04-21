using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{

    GameObject gbPlayer, gbHead;
    public float speed = 1;
    public bool _gazed;
    
    void Start()
    {
        gbPlayer = GameObject.FindGameObjectWithTag("Player");
        gbHead = GameObject.Find("dummyHead").gameObject;
    }


    void Update()
    {
        if (_gazed)
            gbPlayer.transform.position += gbHead.transform.forward * speed;
    }

    public void forward()
    {
        _gazed = true;
    }

    public void stop()
    {
        _gazed = false;
    }
}
