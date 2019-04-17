using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraPointer : MonoBehaviour {
    private GameObject hitObject = null;
    private Vector3 reticlePosition = Vector3.zero;
    private Camera camera;
    int targetMask;
/* 
    void Awake() {
        camera = GetComponent<Camera>();
    }

    void Start() {
        targetMask = LayerMask.GetMask("target");
        Debug.Log(targetMask);
    }
    // Update is called once per frame
    void Update () {

        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        Debug.DrawRay(ray2, Color.green);
        if (Physics.Raycast(ray2, out hit2, 100f, targetMask))
        {
            Debug.Log("Damn!");
            

        }

        // TODO: Replace with reticle screen position
        reticlePosition = Input.mousePosition;

        // Raycast variables
        Ray ray = camera.ScreenPointToRay(reticlePosition); 
        RaycastHit hit;

        // Raycast
        if (Physics.Raycast(ray, out hit)) {
            if (hitObject != hit.transform.gameObject) {
                if (hitObject != null) {
                    hitObject.SendMessage("OnReticleExit"); // Trigger "OnReticleExit"
                }
                hitObject = hit.transform.gameObject;
                hitObject.SendMessage("OnReticleEnter"); // Trigger "OnReticleEnter"
            } else {
                hitObject.SendMessage("OnReticleHover"); // Trigger "OnReticleHover"
            }
        } else {
            if (hitObject != null) {
                hitObject.SendMessage("OnReticleExit"); // Trigger "OnReticleExit"
            }
            hitObject = null;
        }
    }
    */
}