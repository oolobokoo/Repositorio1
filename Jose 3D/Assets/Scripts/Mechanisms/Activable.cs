using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour {

    public bool currentlyActive { get; private set; }
    List<Activator> activators;
    Activator lastActivator;

    // Start is called before the first frame update
    void Start () {

    }

    public bool SetActive (bool state) {
        return currentlyActive = state;
    }
}
