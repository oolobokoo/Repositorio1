using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour {

    List<Checkpoint> checkpoints;
    Checkpoint activeCheckpoint;

    void Awake () {
        checkpoints = new List<Checkpoint> (FindObjectsOfType<Checkpoint> ());
    }

    public void SetCurrentActive (Checkpoint current) {
        activeCheckpoint = current;
        activeCheckpoint.Activate (true);
        foreach (Checkpoint checkpoint in checkpoints.FindAll(point => point != activeCheckpoint)) {
            checkpoint.Activate (false);
        }
    }
}
