using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownCharAnim : MonoBehaviour {

    Rigidbody2D rb2D;
    public Animator playerAnimator;
    public float movSpeed = 50;

    // Start is called before the first frame update
    void Start () {
        rb2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    public void ControlledFixedUpdate () {
        Vector2 horizontal = Input.GetAxisRaw ("Horizontal") * Vector2.right;
        Vector2 vertical = Input.GetAxisRaw ("Vertical") * Vector2.up;

        Vector2 movement = horizontal + vertical;

        playerAnimator.SetBool ("Moving", movement != Vector2.zero);
        playerAnimator.SetFloat ("Horizontal", horizontal.x);
        playerAnimator.SetFloat ("Vertical", vertical.y);

        rb2D.MovePosition (rb2D.position + (movement.normalized * movSpeed * Time.fixedDeltaTime));
    }
}
