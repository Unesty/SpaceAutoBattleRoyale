using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceParts : MonoBehaviour
{
    public List<GameObject> items;
    public GameObject currentItem;
    public int currentID = 0;
    Vector2 mousepos;
    public Camera cam;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        currentItem.layer = LayerMask.NameToLayer ("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {

    }
    RaycastHit hit;
    bool was_hit = false;
    public void ClickCB(InputAction.CallbackContext ctx)
    {
//         if(ctx.canceled) {
//             Instantiate(currentItem, currentItem.transform.position, currentItem.transform.rotation);
//         } else if(ctx.performed) {
//             mousepos = Mouse.current.position.ReadValue();
//             RaycastHit hit;
//             Ray ray = cam.ScreenPointToRay(mousepos);
//             if( Physics.Raycast(ray, out hit, 100f)) {
//                 currentItem.transform.position = hit.point+hit.normal;
//             }
//         } else {
//             mousepos = Mouse.current.position.ReadValue();
//             RaycastHit hit;
//             Ray ray = cam.ScreenPointToRay(mousepos);
//             if( Physics.Raycast(ray, out hit, 100f)) {
//                 currentItem.transform.position = hit.point+hit.normal;
//             }
//         }
        if(ctx.performed) {
            moving = ctx.ReadValue<float>() == 1f;

            if(!moving & was_hit) {
                var iGO = Instantiate(currentItem, currentItem.transform.position, currentItem.transform.rotation);
                iGO.layer = LayerMask.NameToLayer ("Default");
            }
        }
    }
    public void CursorCB(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) {
            if(moving) {
                mousepos = ctx.ReadValue<Vector2>();

                Ray ray = cam.ScreenPointToRay(mousepos);
                was_hit = Physics.Raycast(ray, out hit, 100f);

                if(was_hit) {
                    currentItem.transform.position = hit.point+hit.normal;
                }
            }
        }
    }
    public void MiddleClickCB(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) {

        }
    }
    public void RightClickCB(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) {

        }
    }
    public void ScrollCB(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) {
            int val = (int)Mathf.Round(ctx.ReadValue<Vector2>()[1]);
            if(val < 0) {
                if((currentID + val) < 0) {
                    currentID = items.Count - 1;
                } else {
                    currentID += val;
                    var iGO = Instantiate(items[currentID], currentItem.transform.position, Quaternion.identity);
                    Destroy(currentItem);
                    currentItem = iGO;
                    currentItem.layer = LayerMask.NameToLayer ("Ignore Raycast");
                }
            } else if(val > 0) {
                if((currentID + val) >= items.Count) {
                    currentID = 0;
                } else {
                    currentID += val;
                    var iGO = Instantiate(items[currentID], currentItem.transform.position, Quaternion.identity);
                    Destroy(currentItem);
                    currentItem = iGO;
                    currentItem.layer = LayerMask.NameToLayer ("Ignore Raycast");
                }
            }
        }
    }

}
