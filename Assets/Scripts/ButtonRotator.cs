using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRotator : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 ox;
    private Vector3 dir, dirNew;
    float time = 0;
    void Start()
    {
        //transform.LookAt()
        dir = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        //float 
        //transform.rotation = Quaternion.AngleAxis(10.0f, Vector3.up);
        // avilable 0~30 / 330~360
        Vector3 xx;
        
        //xx = Vector3.Angle(transform.forward, Vector3.forward)>30? Vector3.down: Vector3.up;
        ox = GameObject.Find("AllButton").transform.up;
        Debug.DrawRay(transform.position,ox,Color.green);
        

        /*
        // drive by time
        time += Time.deltaTime;
        if (time<3)
        {
            xx = Vector3.up;

        }
        else
        {
            if ((time-3)%12 < 6)
            {
                    xx = Vector3.down;

            }
            else
            {
                    xx = Vector3.up;

            }
        }

       
        GetComponent<Rigidbody>().angularVelocity =xx * 0.3f;

         */

         /*
        if (Vector3.Angle(transform.forward, Vector3.forward)>30)
        {
                xx = Vector3.down;

        }
        else
        {
                xx = Vector3.up;

        }
         */
        
//        Debug.Log(Vector3.Angle(this.transform.forward, ox));

        if (Vector3.Angle(this.transform.forward, ox) < 150)
        {
            dir =  new Vector3(-dir.x, -dir.y, -dir.z);
            //Debug.Log("Reverse");
        }
        //Debug.DrawRay(transform.position, dir);
        GetComponent<Rigidbody>().angularVelocity = dir;

    }
}
