using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gazeCheck : MonoBehaviour
{
    public float gazeDistance;
    public bool  _isGazed;
    public string gazedObject = null;
    public string temp = null;
    public float gazeTime;

    void Update()
    {
        _isGazed = false;
        RaycastHit hit;
        Ray gazeRay = new Ray(transform.position, transform.rotation * Vector3.forward);
        Debug.DrawRay(transform.position, transform.rotation * Vector3.forward * gazeDistance, Color.red);
        if (Physics.Raycast(gazeRay, out hit, gazeDistance))
        {
            //Debug.Log(hit);
            
                    if (temp == hit.collider.name)
                    {
                        gazeTime = gazeTime + Time.deltaTime;
                        //Debug.Log("==");
                    }
                    else
                    {
                        temp = hit.collider.name;
                        gazeTime = 0;
                        //Debug.Log("=");
                    }

                    if ( (temp != null) && (gazeTime >=3) )
                    {
                        _isGazed = true;
                        gazedObject = temp;
                        //Debug.Log("Hit!" + gazedObject);
                    }
                        
                Debug.Log("Hit!" + hit.collider.name);
                Debug.Log("Temp:" + temp);
                
    
        }
        //Debug.Log("Hit!" + gazedObject);

    }
}
