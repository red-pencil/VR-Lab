using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private deviceCamera pixel;
    private officeCameraController eyeCamera;
    public float pixelPower;
    public float pixelSpeed;

    public bool pixelOn;
    public bool dragToSee=true;
    public bool newLogic;

    public float firstPower = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        pixel = GetComponentInChildren<deviceCamera>();
        eyeCamera = GetComponentInChildren<officeCameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //pixelPower = GetComponentInChildren<deviceCamera>().detectPixel.r * pixelSpeed;
        Vector3 movement= new Vector3(0.0f, 0.0f, 0.0f);
        eyeCamera.dragToSee = dragToSee;
        eyeCamera.newLogic = newLogic;

        if (pixelOn)
            pixelPower = pixel.value * pixelSpeed;
        else
            pixelPower = 0.0f;

        if (newLogic)
        { 
            if (Input.GetMouseButton(0))
                movement = new Vector3 (0.0f, 0.0f, firstPower + pixelPower);

        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical") + pixelPower;
            movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        }
        //rb.velocity = movement * speed;
        movement = this.transform.rotation * movement;
        //Debug.Log("H-axis:"+ Input.GetAxis("Horizontal"));
        this.transform.position += movement * speed;
        //b.AddForce(movement * speed);
    }
}
