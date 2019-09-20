using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSelector : MonoBehaviour {

    bool moveTopdown;
    public TopdownCharAnim topdownCharControl;
    public PlatformerCharAnim platformCharControl;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {
        if (moveTopdown) {
            topdownCharControl.ControlledFixedUpdate ();
        } else {
            platformCharControl.ControlledFixedUpdate ();
        }
    }

    void OnGUI () {
        moveTopdown = GUI.Toggle (new Rect (Screen.width / 2 - 60, 10, 120, 30), moveTopdown, "Topdown ON/OFF");
    }
}
