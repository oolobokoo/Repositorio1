using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveControl : MonoBehaviour {

    public GameObject targetWall;
    public int remainingEnemies;
    public int nextScene;

    // Start is called before the first frame update
    void Start () {
        remainingEnemies = GameObject.FindGameObjectsWithTag ("Hazard").Length;
    }

    // Update is called once per frame
    void Update () {
        if (remainingEnemies <= 0 && targetWall) {
            Destroy (targetWall);
        }
    }
}
