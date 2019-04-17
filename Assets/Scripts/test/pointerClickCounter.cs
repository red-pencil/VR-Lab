using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Required when using Event data.
using UnityEngine.EventSystems;

public class pointerClickCounter : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //Grab the number of consecutive clicks and assign it to an integer variable.
        int i = eventData.clickCount;

        //Display the click count.
        Debug.Log(i);
    }
}
