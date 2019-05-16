using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    GameObject gbPlayer, gbHead;
    GameObject brakeState;
    public float speed = 1;
    public bool _gazed, _gazeMode, _autoForward;
    
    void Start()
    {
        gbPlayer = GameObject.FindGameObjectWithTag("Player");
        gbHead = GameObject.Find("DummyHead").gameObject;
        brakeState = gbPlayer.transform.Find("DummyBody").Find("LosOptions").gameObject;
        _gazeMode = true;
        _autoForward = false;
    }


    void FixedUpdate()
    {
        if (!brakeState.activeSelf)
        {
            if (_gazed)
                gbPlayer.transform.position += gbHead.transform.forward * speed;
            //gbPlayer.GetComponent<Rigidbody>().AddForce(gbHead.transform.forward * speed);

            else if (_autoForward)
                gbPlayer.transform.position += gbHead.transform.forward * speed;

        }
        else
            _autoForward = false;


    }


    public void ShiftAuto()
    {

        _autoForward = !_autoForward;
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
