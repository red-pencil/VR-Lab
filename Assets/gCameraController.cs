using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gCameraController : MonoBehaviour
{
    GameObject gbCamera;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    private float rotationX = 0F;
    private float rotationY = 0F;

    void Start()
    {
        gbCamera = GameObject.Find("playerHead").transform.Find("Main Camera").gameObject;
    }


    void Update()
    {

    }
}
