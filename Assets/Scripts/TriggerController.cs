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
                indicator = "Welcome to ...\nEmpathic Computing Lab...";
                break;

                //default:
                //    indicator = "!!!";
                //    break;

        }

        oracle.text = indicator;
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(3);
        oracle.text = null;
        if (other.name == "OpenDoorTrigger")
            other.gameObject.transform.GetComponentInParent<Elevator>().CloseDoor();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.name == "OpenDoorTrigger")
            other.gameObject.transform.GetComponentInParent<Elevator>().OpenDoor();
        
    }
}