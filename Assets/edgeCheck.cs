using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeCheck : MonoBehaviour
{
    public bool _leftEdge = false;
    public bool _rightEdge = false;

    
    void Start()
    {
        
    }


    void Update()
    {
        _leftEdge = false;
        _rightEdge = false;

    RaycastHit hit;
        float gazeDistance = 20;
        Ray gazeRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * gazeDistance, Color.green);
        if (Physics.Raycast(gazeRay, out hit, gazeDistance))
        {
            Debug.Log("hit - " + hit.collider.name);
            _leftEdge = (hit.collider.name == "leftEdge") ? true : false;
            _rightEdge = (hit.collider.name == "rightEdge") ? true : false;

        }

        
    }
}
