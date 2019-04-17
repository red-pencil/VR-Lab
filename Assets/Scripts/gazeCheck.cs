using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazeCheck : MonoBehaviour
{
    public float gazeDistance;

    public bool  _isGazed;

    void Update()
    {
        _isGazed = false;
        RaycastHit hit;
        Ray gazeRay = new Ray(transform.position, transform.rotation * Vector3.forward);
        Debug.DrawRay(transform.position, transform.rotation * Vector3.forward * gazeDistance, Color.red);
        if (Physics.Raycast(gazeRay, out hit, gazeDistance))
        {
            //Debug.Log(hit);
            if(hit.collider.tag == "button")
                {
                Debug.Log("Gazed!");
                _isGazed = true;
                }
        }
    }
}
