using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text message;
    public GameObject gbHead, gbBody;
    public GameObject menu;
    public GameObject PUI, BUI, bgm, map, cam, thirdCam;
    public GameObject arrow3D, gear3D;
    ButtonController buttonCtrl;

    void Start()
    {
        message.text = "Hello Lichao!";
        gbHead = GameObject.Find("DummyHead");
        gbBody = GameObject.Find("DummyBody");
        bgm = GameObject.Find("Audio Source");

        menu = gbHead.transform.Find("MyMenu").gameObject;
        
        PUI = gbHead.transform.Find("PlainUI").gameObject;
        BUI = gbHead.transform.Find("BottomUI").gameObject;
        map = PUI.transform.Find("Map").gameObject;
        cam = PUI.transform.Find("DeviceCamera").gameObject;
        thirdCam = PUI.transform.Find("ThirdPerson").gameObject;

        arrow3D = gbHead.transform.Find("arrow").gameObject;
        gear3D = gbBody.transform.Find("AllButton").transform.Find("Gear").gameObject;

        buttonCtrl = gbHead.transform.parent.GetComponent<ButtonController>();



    }

    public void OpenPUI()
    {
        PUI.SetActive(!PUI.activeSelf);
        TurnOffMenu();
    }

    public void ToggleAudio()
    {
        bgm.SetActive(!bgm.activeSelf);
        TurnOffMenu();
    }

    public void ToggleBUI()
    {
        BUI.SetActive(!BUI.activeSelf);
        arrow3D.SetActive(!BUI.activeSelf);
        //gear3D.SetActive(!BUI.activeSelf);
        TurnOffMenu();
    }

    public void OpenMap()
    {
        map.SetActive(!map.activeSelf);
        TurnOffMenu();
    }

    public void OpenCamera()
    {
        cam.SetActive(!cam.activeSelf);
        thirdCam.SetActive(!thirdCam.activeSelf);
        TurnOffMenu();
    }

    void TurnOffMenu()
    {
        //menu.SetActive(false);
        buttonCtrl.GearShift();
    }


    void Update()
    {
        
    }
}
