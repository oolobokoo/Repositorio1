using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour {

    public string id;

    void Start () {
        Destroy (gameObject, 4);
    }

    void Update () {
        transform.Translate (Vector3.forward * Time.deltaTime * 4);
    }

    public void Create (Vector3 position, Quaternion rotation) {
        Instantiate (gameObject, position, rotation);
    }
}
