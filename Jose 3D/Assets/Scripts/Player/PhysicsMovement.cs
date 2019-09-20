using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MovScript {

    public Rigidbody rigBod;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Vector3 horizontal = Vector3.up * Input.GetAxis ("Horizontal");
        Vector3 vertical = transform.forward * Input.GetAxis ("Vertical");

        rigBod.MovePosition (rigBod.position + (vertical * speed * Time.deltaTime));
        transform.Rotate (horizontal * angularSpeed * Time.deltaTime);
    }
}
