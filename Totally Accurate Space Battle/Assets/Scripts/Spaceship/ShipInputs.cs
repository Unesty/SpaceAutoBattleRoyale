using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputs : MonoBehaviour
{

    // these inputs are read by ShipMovement
    [HideInInspector] public Vector3 move; // in x,y,z direction
    [HideInInspector] public Vector3 rotate; // on x,y,z axis

    public bool autoPilot = true;
    void Update() {
        if (autoPilot) UpdateInputsAuto();
        else UpdateInputsPlayer();
    }

    void UpdateInputsAuto() {
// todo: Add Autopilot Here
        move = Vector3.zero;
        rotate = Vector3.up;
    }
    void UpdateInputsPlayer() {
        if (Input.GetKey(holdForRotateNotMove)) {
            move = Vector3.zero;
            rotate.x = ParseKeyAxis(backward, forward);
            rotate.y = ParseKeyAxis(left, right);
            rotate.z = ParseKeyAxis(up, down);
        }
        else {
            rotate = Vector3.zero;
            move.z = ParseKeyAxis(backward, forward);
            move.x = ParseKeyAxis(left, right);
            move.y = ParseKeyAxis(down, up);
        }
    }
    int ParseKeyAxis(KeyCode kNeg, KeyCode kPos) {
        if (Input.GetKey(kPos)) return 1;
        if (Input.GetKey(kNeg)) return -1;
        return 0;
    }

    KeyCode holdForRotateNotMove = KeyCode.LeftShift;
    KeyCode forward = KeyCode.W;
    KeyCode backward = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;
    KeyCode up = KeyCode.E;
    KeyCode down = KeyCode.Q;
}
