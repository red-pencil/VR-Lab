using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string gazeObj, pressedObj;
    private GameObject gbButton, gbPlan, gbHead;
    GameObject[] buttons = new GameObject[5];
    private GameObject option, option3D, gear, gear2D, gear3D;
    private GameObject option2D;
    private GameObject menu, BUI;

    public enum DefaultMode
    {
        Icon_2D,
        Icon_3D
    }

    public DefaultMode defaultMode;
    //private gButtonController Switches;


    void Start()
    {
        gbButton = GameObject.Find("AllButton");
        gbPlan = GameObject.Find("OfficeBase");
        gbHead = GameObject.Find("DummyHead");


        option3D = gbButton.transform.Find("Option3D").gameObject;
       
        gear3D = gbButton.transform.Find("Gear").gameObject;
        BUI = gbHead.transform.Find("BottomUI").gameObject;
        gear2D = BUI.transform.Find("MenuButton").gameObject;

        option2D = gbButton.transform.parent.Find("LosOptions").gameObject;

        menu = gbHead.transform.Find("MyMenu").gameObject;

        option3D.SetActive(true);
        gear3D.SetActive(true);
        menu.SetActive(true);
        BUI.SetActive(true);
        gear2D.SetActive(true);
        option2D.SetActive(true);


        buttons = GameObject.FindGameObjectsWithTag("button");

        option2D.SetActive(false);
        option3D.SetActive(false);
        menu.SetActive(false);
        
        

        if (defaultMode == DefaultMode.Icon_2D)
        {
            gear3D.SetActive(false);
            option = option2D;
            gbHead.transform.Find("arrow").gameObject.SetActive(false);
        }
        else if (defaultMode == DefaultMode.Icon_3D)
        {
            gear2D.SetActive(false);
            option = option3D;
            BUI.SetActive(false);
            
        }

        

    }

    public void GearShift()
    {
        gear = BUI.activeSelf ? gear2D : gear3D;
        

        option.SetActive(!option.activeSelf);
        option = BUI.activeSelf ? option2D : option3D;
        menu.SetActive(!menu.activeSelf);
        Debug.Log("this key is " + gear.name);
        gear.SetActive(!gear.activeSelf);


    }

    string ButtonMonitor()
    {
        //bool[] buttonStates = new bool[5];
        //string[] buttonNames = new string[5];
        //GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");

        

        for (int i =0; i <buttons.Length; i++)
        {
            //Debug.Log(buttons[i].name);
            if (buttons[i].GetComponent<ButtonState>()._pressed)
            {
                buttons[i].GetComponent<ButtonState>().SetPress(false);
                buttons[i].GetComponent<ButtonState>().SetGaze(false);
                return buttons[i].name;
            }
                
        }
        return null;
    }



    void Update()
    {
        //gazeObj = GetComponentInChildren<gazeCheck>().gazedObject;
        //Debug.Log("button" + gazeObj);

        pressedObj = ButtonMonitor();

        switch (pressedObj)
        {
            case "Gear":
                GearShift();
                print ("Gear");
                break;

            case "MenuButton":
                GearShift();
                print("MenuButton");
                break;


            case ("AButton"):
                GearShift();

                gbPlan.transform.Find("planA").gameObject.SetActive(true);
                gbPlan.transform.Find("planB").gameObject.SetActive(false);
                gbPlan.transform.Find("planC").gameObject.SetActive(false);

                print ("A");
                break;
            case "BButton":
                GearShift();

                gbPlan.transform.Find("planA").gameObject.SetActive(false);
                gbPlan.transform.Find("planB").gameObject.SetActive(true);
                gbPlan.transform.Find("planC").gameObject.SetActive(false);

                print ("B");
                break;
            case "CButton":
                GearShift();

                gbPlan.transform.Find("planA").gameObject.SetActive(false);
                gbPlan.transform.Find("planB").gameObject.SetActive(false);
                gbPlan.transform.Find("planC").gameObject.SetActive(true);

                print ("C");
                break;
            default:
                print ("no action");
                break;
        }

        //gear3D.SetActive(BUI.activeSelf ? false : true);
        //option.SetActive(!gear.activeSelf);
    }
}
