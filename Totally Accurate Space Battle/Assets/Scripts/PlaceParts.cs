using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceParts : MonoBehaviour
{
    public GameObject currentItem;
    Vector2 mousepos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseCB(InputAction.CallbackContext ctx) {
        //if(ctx.wasPressedThisFrame) {
            mousepos = Mouse.current.position.ReadValue();
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(mousepos);
            if( Physics.Raycast(ray, out hit, 100f)) {
                currentItem.transform.position = hit.point;
            }
        //} else if(ctx.wasReleasedThisFrame) {
            Instantiate(currentItem);
        //}
    }
}
