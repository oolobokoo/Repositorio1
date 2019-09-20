using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : Activator {

    Transform lever;

    // Start is called before the first frame update
    void Start () {
        lever = transform.GetChild (0);
    }

    // Update is called once per frame
    void Update () {

    }

    protected override void ShowAction () {
        Vector3 leverAngles = lever.eulerAngles;
        leverAngles.x *= -1;
        lever.eulerAngles = leverAngles;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerAtributes> ().targetActivator = this;
        }
    }

    void OnTriggerExit (Collider other) {
        PlayerAtributes player = other.GetComponent<PlayerAtributes> ();
        if (player && player.targetActivator == this) {
            player.targetActivator = null;
        }
    }
}
