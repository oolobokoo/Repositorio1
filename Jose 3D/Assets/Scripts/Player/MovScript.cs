using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovScript : MonoBehaviour {

    public float speed = 5;
    public float angularSpeed = 80;
    public Vector3 position { get { return transform.position; } }
    public bool activeControl;

    public Vector3 EqualizeWithLocal (Vector3 vector) {
        return (vector.x * transform.right) + (vector.y * transform.up) + (vector.z * transform.forward);
    }
}
