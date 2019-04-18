using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    public string gazeObj;
    private GameObject gbButton, gbPlan;
    void Start()
    {
        gbButton = GameObject.Find("allButton");
        gbPlan = GameObject.Find("officeBase");
    }

    // Update is called once per frame
    void Update()
    {
        gazeObj = GetComponentInChildren<gazeCheck>().gazedObject;

        //Debug.Log("button" + gazeObj);
        switch (gazeObj)
        {
        case "gear":
        {
            gbButton.transform.Find("gear").gameObject.SetActive(false);
            gbButton.transform.Find("optionA").gameObject.SetActive(true);
            gbButton.transform.Find("optionB").gameObject.SetActive(true);
            gbButton.transform.Find("optionC").gameObject.SetActive(true);
            print ("gear");
            break;
        }
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
            //print ("no action");
            break;
        }
    }
}
