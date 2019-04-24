using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deviceCamera : MonoBehaviour
{
    WebCamDevice[] devices;
    WebCamDevice backCam;
    
    WebCamTexture webcamTexture;
    public Texture warnTexture;

    public Color[] detectPixels;
    public Color detectPixel;
    //private float[] detectAlpha = new float[100];
    public float value;
    //Color32[] dataX;


    void Start()
    {
        devices = WebCamTexture.devices;

        /*
        foreach (WebCamDevice cam in devices){
            Debug.Log("camFront:" + cam.isFrontFacing);
        if(!cam.isFrontFacing){
            rearCamera = cam;
            break;
            }
        }
        */

        Renderer renderer = GetComponent<Renderer>();

        if (devices.Length == 0)
        {
            renderer.material.mainTexture = warnTexture;
            return;
        }


        if (devices.Length == 1)
        {
            webcamTexture = new WebCamTexture(devices[0].name);

        }

        if (devices.Length > 1)
        {
            for(int i=0; i < devices.Length; i++)
            {
               if (!(devices[i].isFrontFacing))
                {
                    webcamTexture = new WebCamTexture(devices[i].name); 
                    break;
                }
            }
        }

        
        webcamTexture.Play();
        renderer.material.mainTexture = webcamTexture;

        //data = new Color32[1280 * 720];

    }


    void Update()
    {
       /*
        webcamTexture.GetPixels32(data);
        Debug.Log(data[500000].g);
         */

        Color.RGBToHSV(webcamTexture.GetPixel(350, 350), out value, out value, out value);

        // use red channel
        //detectPixel = webcamTexture.GetPixel(350, 350);
        //Debug.Log(detectPixel.r);


/*
        // use array of pixels
        //detectPixels =  webcamTexture.GetPixels(350, 350, 10, 10);
        for (int i=0; i < detect.Length; i++)
        {
            detectAlpha[i] = detect[i].grayscale;
            Debug.Log(detectAlpha[i]);

        }
*/       
    }
}
