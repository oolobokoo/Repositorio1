using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 2;
    public Vector3 direction = Vector3.right;
    public float lifespan = 1.5f;
    // Start is called before the first frame update
    void Start () {
        Destroy (gameObject, lifespan);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate (direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other) {
        //TODO: Damage or Destroy Enemy
        if (other.CompareTag("Hazard")) {
            Destroy (other.gameObject);
        }
        if (!other.CompareTag ("CamArea")) {
            Destroy (gameObject);
        }
    }
}
