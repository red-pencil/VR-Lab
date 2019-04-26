using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    GameObject leftDoor, rightDoor;
    public float interval = 6.0f;
    public bool _activated = false;
    private Vector3 doorPos;
    private float scalar;


    void Start()
    {
        leftDoor = this.gameObject.transform.GetChild(0).gameObject;
        rightDoor = this.gameObject.transform.GetChild(1).gameObject;
        doorPos = (leftDoor.transform.localPosition + rightDoor.transform.localPosition)/2;

    }

    void LateUpdate()
    {

    }

    public void OpenDoor()
    {
        scalar = Mathf.Abs(Mathf.Sin(Time.time));

        leftDoor.transform.localScale = new Vector3(scalar, 3f, 0.1f);
        leftDoor.transform.localPosition = new Vector3(doorPos.x - 1.0f + 0.5f * scalar, doorPos.y, doorPos.z);

        rightDoor.transform.localScale = new Vector3(scalar, 3f, 0.1f);
        rightDoor.transform.localPosition = new Vector3(doorPos.x + 1.0f - 0.5f * scalar, doorPos.y, doorPos.z);

    }

    public void CloseDoor()
    {
        scalar = 1;

        leftDoor.transform.localScale = new Vector3(scalar, 3f, 0.1f);
        leftDoor.transform.localPosition = new Vector3(doorPos.x - 1.0f + 0.5f * scalar, doorPos.y, doorPos.z);

        rightDoor.transform.localScale = new Vector3(scalar, 3f, 0.1f);
        rightDoor.transform.localPosition = new Vector3(doorPos.x + 1.0f - 0.5f * scalar, doorPos.y, doorPos.z);

    }

}
