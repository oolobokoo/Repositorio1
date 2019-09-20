using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MovScript {

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Vector3 horizontal = Vector3.up * Input.GetAxis ("Horizontal");
        Vector3 vertical = Vector3.forward * Input.GetAxis ("Vertical");
        Vector3 transversal = Vector3.up * GetTransversalAxis ();

        transform.Translate ((vertical + transversal).normalized * speed * Time.deltaTime);
        transform.Rotate (horizontal * angularSpeed * Time.deltaTime);
    }

    float GetTransversalAxis () {
        float axisResult = 0;
        if (Input.GetKey(KeyCode.Space)) {
            axisResult += 1;
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            axisResult -= 1;
        }
        return axisResult;
    }
}
