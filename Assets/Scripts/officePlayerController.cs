using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private deviceCamera pixel;
    public float pixelPower;
    public float pixelSpeed;

    public bool dragToSee;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        pixel = GetComponent<deviceCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //pixelPower = GetComponentInChildren<deviceCamera>().detectPixel.r * pixelSpeed;
        pixelPower = GetComponentInChildren<deviceCamera>().value * pixelSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") + pixelPower;
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;
        movement = this.transform.rotation * movement;
        this.transform.position += movement * speed;


        //rb.AddForce(movement * speed);
    }
}
