using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.UI;

public class buttonFoward : MonoBehaviour
{
    public bool _isGazed =  false;
    void Start()
    {
        
    }

    public void Forward()
    {
        _isGazed = true;
        Debug.Log("Is Gazed!");

    }

    public void Stop()
    {
        _isGazed = false;
        Debug.Log("NOT Gazed!");
    }
    void Update()
    {
        
    }
}
