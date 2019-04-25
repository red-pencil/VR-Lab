using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotController : MonoBehaviour
{
    public GameObject realPlayer;
    public float scale = 1;
    //public float offsetX = 0;
    //public float offsetY = 0;
    Vector2 dotPos;
    Vector3 playerOriginalPos;

    void Start()
    {

        dotPos = GetComponent<RectTransform>().anchoredPosition;
        playerOriginalPos = realPlayer.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX, offsetY;
        offsetX = (realPlayer.transform.localPosition.x - playerOriginalPos.x) * scale;
        offsetY = (realPlayer.transform.localPosition.z - playerOriginalPos.z) * scale;
        GetComponent<RectTransform>().anchoredPosition = dotPos + new Vector2(-offsetX, -offsetY);
    }
}
