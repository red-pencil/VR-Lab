using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public bool _gazed;
    public bool _pressed = false;

    public bool _timeMode;
    public float timeCounter;

    public Material inactiveMaterial, gazedAtMaterial;
    private Renderer myRenderer;

    private Graphic m_Graphic;

    private Color m_Color;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetGaze(false);
        SetPress(false);
        //Debug.Log("START" + gameObject.name);
        if (GetComponent<RawImage>() && GetComponent<RawImage>().texture)
        {
            m_Color = new Color32(54, 255, 237, 255);
            m_Graphic = GetComponent<RawImage>();

        }
            
    }

    void Update()
    {

        // Debug.Log("UPDATE" + gameObject.name);

        timeCounter = _gazed ? timeCounter + Time.deltaTime : 0;

        if (!_gazed)
        {
            SetPress(false);
            if (m_Graphic)
                m_Graphic.color = m_Color;
        }
        //Debug.Log("a");
        else
        {
            if (_timeMode)
            {
                SetPress(false);
                
                SetPress((timeCounter >= 1) ? true : false);
                //float r = 54f + timeCounter * 20f;
                //buttonColor = new Color32((int)r, 255, 237, 255);
                if (m_Graphic)
                    m_Graphic.color = Color.Lerp(new Color32(54, 255, 237, 255), Color.red, 1);
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

    public void GazeSetPress(bool _setGaze)
    {
        _gazed = _setGaze;
        StartCoroutine(GazeWait());
        //_pressed = _setPress;

    }

    IEnumerator GazeWait()
    {
        //print(Time.time);
        yield return new WaitForSeconds(2);
        //print(Time.time);
        if (_gazed)
            _pressed = !_pressed;
    }

    public void TurnOffAuto()
    {
        if (this.transform.parent.Find("ForwardButton"))
        {
            this.transform.parent.Find("ForwardButton").gameObject.GetComponent<MoveForward>()._autoForward = false;

        }
        
    }


}
