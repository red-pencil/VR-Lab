using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{

    GameObject gbPlayer, gbHead;
    public float speed = 1;
    public bool _gazed, _gazeMode;
    
    void Start()
    {
        gbPlayer = GameObject.FindGameObjectWithTag("Player");
        gbHead = GameObject.Find("dummyHead").gameObject;
        _gazeMode = true;
    }


    void Update()
    {
        if (_gazed)
            gbPlayer.transform.position += gbHead.transform.forward * speed;
    }

    public void Forward()
    {
        _gazed = _gazeMode ? true : _gazed;
    }

    public void Stop()
    {
        _gazed = _gazeMode ? false : _gazed;
    }
    
    public void Press()
    {
        //_gazed = !_gazed;
        _gazeMode = !_gazeMode;
    }
}
