using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public string gazeObj, pressedObj;
    private GameObject gbButton, gbPlan, gbHead;
    GameObject[] buttons = new GameObject[5];
    private GameObject optionA, optionB, optionC, gear;
    private GameObject menu;
    //private gButtonController Switches;


    void Start()
    {
        gbButton = GameObject.Find("allButton");
        gbPlan = GameObject.Find("officeBase");
        gbHead = GameObject.Find("dummyHead");


        optionA = gbButton.transform.Find("optionA").gameObject;
        optionB = gbButton.transform.Find("optionB").gameObject;
        optionC = gbButton.transform.Find("optionC").gameObject;
        gear = gbButton.transform.Find("gear").gameObject;

        menu = gbHead.transform.Find("MyMenu").gameObject;

        optionA.SetActive(true);
        optionB.SetActive(true);
        optionC.SetActive(true);
        gear.SetActive(true);
        menu.SetActive(true);


        buttons = GameObject.FindGameObjectsWithTag("button");

        optionA.SetActive(false);
        optionB.SetActive(false);
        optionC.SetActive(false);
        menu.SetActive(false);
    }

    public void GearShift()
    {

        optionA.SetActive(!optionA.activeSelf);
        optionB.SetActive(!optionB.activeSelf);
        optionC.SetActive(!optionC.activeSelf);
        menu.SetActive(!menu.activeSelf);

        gear.SetActive(!gear.activeSelf);

    }

    string ButtonMonitor()
    {
        //bool[] buttonStates = new bool[5];
        //string[] buttonNames = new string[5];
        //GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        
        for (int i =0; i <buttons.Length; i++)
        {
            //Debug.Log(buttons[i]);
            if (buttons[i].GetComponent<gButtonController>()._pressed)
            {
                buttons[i].GetComponent<gButtonController>().SetPress(false);
                buttons[i].GetComponent<gButtonController>().SetGaze(false);
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
            case "gear":
                GearShift();
                print ("gear");
                break;

            case "a":
                GearShift();

                gbPlan.transform.Find("planA").gameObject.SetActive(true);
                gbPlan.transform.Find("planB").gameObject.SetActive(false);
                gbPlan.transform.Find("planC").gameObject.SetActive(false);

                print ("A");
                break;
            case "b":
                GearShift();

                gbPlan.transform.Find("planA").gameObject.SetActive(false);
                gbPlan.transform.Find("planB").gameObject.SetActive(true);
                gbPlan.transform.Find("planC").gameObject.SetActive(false);

                print ("B");
                break;
            case "c":
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
    }
}
