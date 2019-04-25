using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public Text oracle;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        string doorName = other.name;
        string indicator = "";
        switch (doorName)
        {
            case "DoorMark":
                indicator = "Here is Mark's room...";
                break;

            case "DoorLab":
                indicator = "Welcome to ...\nSympathic Coumptuing Lab...";
                break;

            //default:
            //    indicator = "!!!";
            //    break;

        }

        oracle.text = indicator;
    }

    private IEnumerator OnTriggerExit()
    {
        yield return new WaitForSeconds(3);
        oracle.text = null;
    }
}