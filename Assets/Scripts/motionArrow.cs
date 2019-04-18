using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, (transform.localPosition.y < 0.05 )? transform.localPosition.y + Time.deltaTime*0.05f: 0.0f, transform.localPosition.z);

    }
}
