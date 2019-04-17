using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pointerTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float timeCount;

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag: " + data.position);
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 1.0f)
            {
                Debug.Log("Dragging:" + data.position);
                timeCount = 0.0f;
            }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("OnEndDrag: " + data.position);
    }
}
