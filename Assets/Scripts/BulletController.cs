using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour{

    public float speed = 20f;

    public GameObject camera;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb.velocity = transform.right * speed;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        
        if (transform.position.x >= (camera.transform.position.x + 3)) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag.Equals("enemy")){
            Destroy(collision.gameObject);
        }
    }
}
