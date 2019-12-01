using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController: MonoBehaviour {
    public bool isGrounded = false, isFacingRight = false;
    public Transform batas1, batas2;

    float speed = 2;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isGrounded) {
            if (isFacingRight) {
                MoveRight();
            } else {
                MoveLeft();
            }

            if (transform.position.x >= batas2.position.x && isFacingRight) {
                Flip();
            } else if (transform.position.x <= batas1.position.x && !isFacingRight) {
                Flip();
            }
        }
    }

    void MoveRight() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (!isFacingRight) {
            Flip();
        }
    }
    
    void MoveLeft() {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
        if (isFacingRight) {
            Flip();
        }
    }

    void Flip() {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}