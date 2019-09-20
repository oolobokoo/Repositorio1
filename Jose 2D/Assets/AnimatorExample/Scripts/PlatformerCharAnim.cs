using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCharAnim : MonoBehaviour {

    Rigidbody2D rb2D;
    public Collider2D playerCollider;
    public Animator playerAnimator;
    public SpriteRenderer playerRenderer;
    public float movSpeed;
    public float jumpForce = 15;
    public float gravity = 10;
    float vertSpeed;
    bool grounded;

    float width { get { return playerCollider.bounds.size.x; } }
    float height { get { return playerCollider.bounds.size.y; } }
    Vector3 leftCorner { get { return transform.position - (Vector3.right * width / 2); } }
    Vector3 rightCorner { get { return transform.position + (Vector3.right * width / 2); } }

    float detectionDistance = 0.1f;

    // Start is called before the first frame update
    void Start () {
        rb2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    public void ControlledFixedUpdate () {
        RaycastHit2D leftHit = Physics2D.Raycast (leftCorner, Vector3.down, detectionDistance);
        RaycastHit2D rightHit = Physics2D.Raycast (rightCorner, Vector3.down, detectionDistance);

        if (leftHit || rightHit) {
            grounded = true;
        } else {
            grounded = false;
        }

        Vector2 horizontal = Input.GetAxisRaw ("Horizontal") * Vector2.right;
        Vector2 vertical = Vector2.up * vertSpeed * Time.fixedDeltaTime;

        if (!grounded) {
            vertSpeed -= gravity * Time.fixedDeltaTime;
        } else {
            if (vertSpeed < 0) {
                vertSpeed = 0;
            }
            if (Input.GetKeyDown (KeyCode.Space)) {
                vertSpeed = jumpForce;
            }
        }

        if (horizontal.x > 0 && playerRenderer.flipX) {
            playerRenderer.flipX = false;
        } else if (horizontal.x < 0 && !playerRenderer.flipX) {
            playerRenderer.flipX = true;
        }

        playerAnimator.SetBool ("Moving", horizontal != Vector2.zero);

        rb2D.MovePosition (rb2D.position + ((horizontal + vertical) * movSpeed * Time.fixedDeltaTime));
    }
}
