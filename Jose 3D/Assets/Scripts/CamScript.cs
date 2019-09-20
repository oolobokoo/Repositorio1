using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public MovScript movingTarget;
    public Vector3 distanceFromTarget;
    Vector3 distancePoint { get { return movingTarget.position + movingTarget.EqualizeWithLocal (distanceFromTarget); } }

    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void LateUpdate () {
        if (movingTarget) {
            if (movingTarget.activeControl) {
                transform.position = distancePoint;
            }
            transform.LookAt (movingTarget.transform);
        }
    }

    void OnDrawGizmos () {
        if (movingTarget) {
            Gizmos.DrawWireSphere (distancePoint, 0.25f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine (distancePoint, movingTarget.position);
        }
    }
}
