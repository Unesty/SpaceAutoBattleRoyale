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
    [SerializeField] bool SnapGrid = false;
    [SerializeField] Vector3 cellSize = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] GameObject Axes;
    [SerializeField] GameObject[] Axis = new GameObject[3];
    [SerializeField] bool[] SelectedAxis = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        currentItem.layer = LayerMask.NameToLayer ("Ignore Raycast");
        Axes.transform.SetParent(currentItem.transform);
        Axes.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedAxis[0]) {
//             Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousepos[0], mousepos[1], currentItem.transform.position[2]));
            Vector3 point = new Vector3(currentItem.transform.position[0]+mousepos[0],0,0);
            currentItem.transform.position = new Vector3(point[0], currentItem.transform.position[1], currentItem.transform.position[2]);
        } else if(SelectedAxis[1]) {
//             Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousepos[0], mousepos[1], currentItem.transform.position[0]));
            Vector3 point = new Vector3(0,currentItem.transform.position[1]+mousepos[1],0);
            currentItem.transform.position = new Vector3(currentItem.transform.position[0], point[1],  currentItem.transform.position[2]);
        } else if(SelectedAxis[2]) {
//             Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousepos[0], mousepos[1], currentItem.transform.position[1]));
            Vector3 point = new Vector3(0, 0, currentItem.transform.position[2]+mousepos[0]);
            currentItem.transform.position = new Vector3(currentItem.transform.position[1], currentItem.transform.position[2], point[2]);

        }
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
                    if(hit.transform.gameObject == Axis[0]) {
                        SelectedAxis[0] = true;
//                         Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousepos[0], mousepos[1], currentItem.transform.position[2]));
//                         currentItem.transform.position = new Vector3(point[0], currentItem.transform.position[1], currentItem.transform.position[2]);
                    } else
                    if(hit.transform.gameObject == Axis[1]) {
                        SelectedAxis[1] = true;
                    } else
                    if(hit.transform.gameObject == Axis[2]) {
                        SelectedAxis[2] = true;
                    } else if(SnapGrid) {
                        currentItem.transform.position = (new Vector3(Mathf.Round((hit.point[0]+hit.normal[0])/cellSize[0])*cellSize[0], Mathf.Round(hit.point[1]+hit.normal[1]/cellSize[1])*cellSize[1], Mathf.Round(hit.point[2]+hit.normal[2]/cellSize[2])*cellSize[2]));
                    } else {
                        currentItem.transform.position = hit.point+hit.normal;
                    }
                }
            }
        }
    }
    public void MiddleClickCB(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) {
            //pick an item
            if(was_hit) {
                if(hit.transform.gameObject) {
                    currentItem = hit.transform.gameObject;
                    Axes.transform.SetParent(currentItem.transform);
                    Axes.transform.position = Vector3.zero;
                }
            }
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
            Axes.transform.SetParent(currentItem.transform);
            Axes.transform.position = Vector3.zero;
        }
    }
}
