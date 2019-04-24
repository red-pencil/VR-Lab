using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text message;
    public GameObject menu;
    public GameObject PUI, map, cam;
    buttonController buttonCtrl;

    void Start()
    {
        message.text = "Hello player!";
        menu = GameObject.Find("MyMenu");
        PUI = GameObject.Find("plainUI");
        map = PUI.transform.Find("map").gameObject;
        cam = PUI.transform.Find("deviceCamera").gameObject;
        buttonCtrl = GameObject.Find("player").GetComponent<buttonController>();
    }

    public void OpenPUI()
    {
        PUI.SetActive(!map.activeSelf);
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
