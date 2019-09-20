using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtilities;

public class Checkpoint : MonoBehaviour {

    public PointData pointData { get; private set; }
    bool active;

    // Awake is called before the first frame update AND THE START :D
    void Awake () {
        pointData = new PointData ((transform.position + Vector3.up).UnityToFloatArray (), transform.rotation.UnityToFloatArray ());
    }

    public void Activate (bool setActive) {
        active = setActive;
        Renderer rend = GetComponent<Renderer> ();
        if (active) {
            rend.material.color = Color.green;
        } else {
            rend.material.color = Color.white;
        }
    }
}
