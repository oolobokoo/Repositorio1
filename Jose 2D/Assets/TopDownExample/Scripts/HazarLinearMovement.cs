using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazarLinearMovement : MonoBehaviour {

    public float speed = 1;
    int direction = 1;
    int currentPathIndex = 0;
    public Vector3[] pathPoints;

    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards (transform.position, pathPoints[currentPathIndex], speed * Time.deltaTime);
        if (transform.position == pathPoints[currentPathIndex]) {
            currentPathIndex += direction;
            if (currentPathIndex >= pathPoints.Length || currentPathIndex < 0) {
                direction *= -1;
                currentPathIndex += direction;
            } 
        }
    }

    void OnDestroy () {
        FindObjectOfType<ObjectiveControl> ().remainingEnemies--;
    }

    void Reset () {
        pathPoints = new Vector3[1];
        pathPoints[0] = transform.position;
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.green;
        for (int i = 0; i < pathPoints.Length; i++) {
            if ((i + 1) < pathPoints.Length) {
                Gizmos.DrawLine (pathPoints[i], pathPoints[i + 1]);
            }
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < pathPoints.Length; i++) {
            Gizmos.DrawSphere (pathPoints[i], 0.15f);
        }
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay (transform.position, transform.up);
        Gizmos.DrawRay (transform.position, transform.right);
    }
}
