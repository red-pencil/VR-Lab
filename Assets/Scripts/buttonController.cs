using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public string gazeObj, pressedObj;
    private GameObject gbButton, gbPlan;


    void Start()
    {
        gbButton = GameObject.Find("allButton");
        gbPlan = GameObject.Find("officeBase");
    }

    string buttonMonitor()
    {
        //bool[] buttonStates = new bool[5];
        //string[] buttonNames = new string[5];
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        
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

        pressedObj = buttonMonitor();

        switch (pressedObj)
        {
        case "gear":
            gbButton.transform.Find("gear").gameObject.SetActive(false);
            gbButton.transform.Find("optionA").gameObject.SetActive(true);
            gbButton.transform.Find("optionB").gameObject.SetActive(true);
            gbButton.transform.Find("optionC").gameObject.SetActive(true);

            print ("gear");
            break;
        case "a":
            gbButton.transform.Find("optionA").gameObject.SetActive(false);
            gbButton.transform.Find("optionB").gameObject.SetActive(false);
            gbButton.transform.Find("optionC").gameObject.SetActive(false);

            gbButton.transform.Find("gear").gameObject.SetActive(true);

            gbPlan.transform.Find("planA").gameObject.SetActive(true);
            gbPlan.transform.Find("planB").gameObject.SetActive(false);
            gbPlan.transform.Find("planC").gameObject.SetActive(false);

            print ("A");
            break;
        case "b":
            gbButton.transform.Find("optionA").gameObject.SetActive(false);
            gbButton.transform.Find("optionB").gameObject.SetActive(false);
            gbButton.transform.Find("optionC").gameObject.SetActive(false);

            gbButton.transform.Find("gear").gameObject.SetActive(true);

            gbPlan.transform.Find("planA").gameObject.SetActive(false);
            gbPlan.transform.Find("planB").gameObject.SetActive(true);
            gbPlan.transform.Find("planC").gameObject.SetActive(false);

            print ("B");
            break;
        case "c":
            gbButton.transform.Find("optionA").gameObject.SetActive(false);
            gbButton.transform.Find("optionB").gameObject.SetActive(false);
            gbButton.transform.Find("optionC").gameObject.SetActive(false);

            gbButton.transform.Find("gear").gameObject.SetActive(true);

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
