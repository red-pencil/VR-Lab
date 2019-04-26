using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    Camera thirdCam;
    Renderer newRenderer;
    RenderTexture newT;

    void Start()
    {
        thirdCam = Camera.allCameras[0];
        newRenderer = GetComponent<Renderer>();
        thirdCam.targetTexture = newT;


    }

    // Update is called once per frame
    void Update()
    {
        newRenderer.material.mainTexture = newT;
    }
}
