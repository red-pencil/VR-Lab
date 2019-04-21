using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gButtonController : MonoBehaviour
{
    public bool _gazed;
    public bool _pressed = false;

    public bool _timeMode;
    public float timeCounter;

    public Material inactiveMaterial, gazedAtMaterial;
    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetGaze(false);
    }

    void Update()
    {

        if (_timeMode)
        {
            _pressed = false;
            timeCounter = _gazed ? timeCounter + Time.deltaTime : 0;
            SetPress((timeCounter >= 2) ? true : false);
        }
            


    }

    public void SetGaze(bool _setGaze)
    {
        _gazed = _setGaze;

        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = _gazed ? gazedAtMaterial : inactiveMaterial;
            return;
        }

    }

    public void SetPress(bool _setPress)
    {
        _pressed = _setPress;
    }


}
