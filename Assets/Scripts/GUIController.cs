using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text message;
    public GameObject menu;
    public GameObject PUI, map, cam;
    ButtonController buttonCtrl;

    void Start()
    {
        message.text = "Hello Lichao!";
        menu = GameObject.Find("MyMenu");
        PUI = GameObject.Find("PlainUI");
        map = PUI.transform.Find("Map").gameObject;
        cam = PUI.transform.Find("DeviceCamera").gameObject;
        buttonCtrl = GameObject.Find("Player").GetComponent<ButtonController>();
    }

    public void OpenPUI()
    {
        PUI.SetActive(!PUI.activeSelf);
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
