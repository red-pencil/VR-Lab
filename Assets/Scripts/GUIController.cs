using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text message;
    public GameObject menu;
    public GameObject PUI, bgm, map, cam, thirdCam;
    ButtonController buttonCtrl;

    void Start()
    {
        message.text = "Hello Lichao!";
        menu = GameObject.Find("MyMenu");
        bgm = GameObject.Find("Audio Source");
        PUI = GameObject.Find("PlainUI");
        map = PUI.transform.Find("Map").gameObject;
        cam = PUI.transform.Find("DeviceCamera").gameObject;
        thirdCam = PUI.transform.Find("ThirdPerson").gameObject;
        buttonCtrl = GameObject.Find("Player").GetComponent<ButtonController>();
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
