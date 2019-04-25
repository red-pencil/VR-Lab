using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour
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
        SetPress(false);
        //Debug.Log("START" + gameObject.name);
    }

    void Update()
    {

        // Debug.Log("UPDATE" + gameObject.name);


        if (!_gazed)
            SetPress(false);
            //Debug.Log("a");
        else
        {
            if (_timeMode)
            {
                SetPress(false);
                timeCounter = _gazed ? timeCounter + Time.deltaTime : 0;
                SetPress((timeCounter >= 2) ? true : false);
            }

            //if (_pressed)
            //    Debug.Log(gameObject.name + "is pressed");

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
