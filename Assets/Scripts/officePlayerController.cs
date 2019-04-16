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

    public bool pixelOn;
    public bool dragToSee=true;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        pixel = GetComponentInChildren<deviceCamera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //pixelPower = GetComponentInChildren<deviceCamera>().detectPixel.r * pixelSpeed;
        
        GetComponentInChildren<officeCameraController>().dragToSee = dragToSee;

        if (pixelOn)
            pixelPower = pixel.value * pixelSpeed;
        else
            pixelPower = 0.0f;
        

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical") + pixelPower;

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        
        //rb.velocity = movement * speed;
        movement = this.transform.rotation * movement;
        Debug.Log("H-axis:"+ Input.GetAxis("Horizontal"));
        this.transform.position += movement * speed;
        //b.AddForce(movement * speed);
    }
}
