using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float tilt;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;
        movement = this.transform.rotation * movement;
        this.transform.position += movement * speed;


        //rb.AddForce(movement * speed);
    }
}
