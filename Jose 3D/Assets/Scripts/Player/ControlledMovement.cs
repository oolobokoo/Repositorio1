using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MovScript {

    public float gravity;
    public CharacterController characterController;
    public PlayerAtributes playerAtributes;
    Animator playerAnimator;
    float verticalSpeed;
    public float jumpForce = 10;
    bool grounded { get { return groundCount > 0 || persistence; } }
    int groundCount { get { return groundCollection.Count; } }
    List<Ground> groundCollection = new List<Ground> ();
    bool persistence;

    MovingPlatform currentPlatform;

    class Ground {
        public Collider collider;
        public Vector3 contactNormal;

        public Ground(Collider collider, Vector3 contactNormal) {
            this.collider = collider;
            this.contactNormal = contactNormal;
        }
    }

    // Start is called before the first frame update
    void Start () {
        playerAnimator = transform.GetChild (0).GetComponent<Animator> ();
        characterController.detectCollisions = false;
    }

    // Update is called once per frame
    void Update () {
        if (!grounded) {
            verticalSpeed -= gravity * Time.deltaTime;
        } else {
            verticalSpeed = persistence ? verticalSpeed - (gravity * Time.deltaTime) : 0;

            if (activeControl) {
                if (Input.GetKeyDown (KeyCode.Space)) {
                    verticalSpeed = jumpForce;
                } else if (Input.GetKeyDown (KeyCode.E) && playerAtributes.targetActivator) {
                    playerAtributes.targetActivator.Activate ();
                }
            }
        }
        float forward = activeControl ? Input.GetAxis ("Vertical") : 0;
        playerAnimator.SetFloat ("ForwardAxis", forward);
        Vector3 forwardAxis = transform.forward * speed * forward;
        Vector3 verticalAxis = Vector3.up * verticalSpeed;
        Vector3 horizontal = Vector3.up * Input.GetAxis ("Horizontal");

        playerAnimator.SetBool ("Grounded", grounded);
        Vector3 movement = (forwardAxis + verticalAxis) * Time.deltaTime;
        if (currentPlatform) { movement += currentPlatform.lastMovement; }
        characterController.Move (movement);
        transform.Rotate (horizontal * angularSpeed * Time.deltaTime);
    }

    void OnCollisionStay (Collision collision) {
        Debug.DrawRay (collision.contacts[0].point, collision.contacts[0].normal, Color.red);

        for (int i = 0; i < collision.contactCount; i++) {
            if (Vector3.Dot (collision.contacts[i].normal, Vector3.up) > 0.8) {
                if (groundCollection.Find(ground => ground.collider == collision.collider) == null) {
                    groundCollection.Add (new Ground(collision.collider, collision.contacts[i].normal));
                    currentPlatform = collision.gameObject.GetComponent<MovingPlatform> ();
                }
            }
        }
    }

    void OnCollisionExit (Collision collision) {
        Ground exitGround = groundCollection.Find (ground => ground.collider == collision.collider);
        if (exitGround != null) {
            if (exitGround.collider.GetComponent<MovingPlatform> ()) {
                currentPlatform = null;
            }
            persistence = Vector3.Dot (exitGround.contactNormal, Vector3.up) < 1 && verticalSpeed <= 0;
            groundCollection.Remove (exitGround);
            StartCoroutine (RecheckPersistance ());
        }
        Debug.Log (persistence);
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay (transform.GetChild (0).position, Vector3.down * 0.15f);
    }

    IEnumerator RecheckPersistance () {
        yield return new WaitForSeconds (0.25f);
        persistence = false;
    }
}
