using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private DeviceCamera pixel;
    private officeCameraController eyeCamera;
    private gazeCheck button;
    public float pixelPower;
    public float pixelSpeed;

    public bool pixelOn;
    public bool dragToSee=true;
    public bool newLogic;

    public float firstPower = 0;
    public float buttonPower;

    private float axisPowerX;
    private float axisPowerY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        pixel = GetComponentInChildren<DeviceCamera>();
        eyeCamera = GetComponentInChildren<officeCameraController>();
        button = GetComponentInChildren<gazeCheck>();
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

        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;
        
        // button part

        if (button.gazedObject == "arrow")
        {
            buttonPower += Time.deltaTime * 1.0f;
            //Debug.Log(Time.del);
            //moveVertical = buttonPower;
        }
        else
        {
            buttonPower = 0;
            //moveVertical = 0;

        }
        
        // camera part

        if (pixelOn)
            pixelPower = pixel.value * pixelSpeed;
        else
            pixelPower = 0.0f;

        // auto part

        if (newLogic && Input.GetMouseButton(0))
        {
            firstPower = 1;
        }
        else
            firstPower = 0;

        
        if (!newLogic)
        {
            axisPowerX = Input.GetAxis("Horizontal");
            axisPowerY = Input.GetAxis("Vertical");   
        }
        else
        {
            axisPowerX = 0;
            axisPowerY = 0;
        }

        //Debug.Log(firstPower);
        moveVertical =  axisPowerY + pixelPower + buttonPower + firstPower;
        //Debug.Log("axis:"+ axisPowerY +"pixel:"+ pixelPower + "button:"+buttonPower + "first:"+firstPower);
        moveHorizontal = axisPowerX;
        movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;
        movement = this.transform.rotation * movement;
       
        this.transform.position += movement * speed;
        //b.AddForce(movement * speed);
    }
}
