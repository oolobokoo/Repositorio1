using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public List<Activable> activables;

    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

    }

    protected virtual void ShowAction () {

    }

    public void Activate () {
        ShowAction ();
        foreach (Activable activable in activables) {
            activable.SetActive (!activable.currentlyActive);
        }
    }
}
