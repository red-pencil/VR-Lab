using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deviceCamera : MonoBehaviour
{

    WebCamTexture webcamTexture;

    public Color[] detect;
    public Color detectPixel;
    //private float[] detectAlpha = new float[100];

    Color32[] data;
    void Start()
    {
        webcamTexture = new WebCamTexture(72,128);
        /*
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        */
        webcamTexture.Play();

        //data = new Color32[1280 * 720];
        
    }


    void Update()
    {
        //Debug.Log(webcamTexture.height + "X" + webcamTexture.width);
       /*
        webcamTexture.GetPixels32(data);
        Debug.Log(data[500000].g);
         */

        detectPixel = webcamTexture.GetPixel(350, 350);
        Debug.Log(detectPixel.r);


/*
        //detect =  webcamTexture.GetPixel(350, 350, 10, 10);
        for (int i=0; i < detect.Length; i++)
        {
            detectAlpha[i] = detect[i].grayscale;
            Debug.Log(detectAlpha[i]);

        }
*/       
    }
}
