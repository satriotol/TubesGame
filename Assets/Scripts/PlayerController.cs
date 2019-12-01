using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    public static PlayerController playerController;
    public AudioClip coin, dead, shot, jump;
    public float score = 0;
    public Text textCoin;
    public Transform firePoint;
    public GameObject bullet;
    public Vector3 respawnPoint;

    bool isJump = true;
    bool isDead = false;
    int idMove = 0;

    Animator anim;
    AudioSource audio;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.A)){
	            MoveLeft();
	        }
	        if (Input.GetKeyDown(KeyCode.D)){
	            MoveRight();
	        }
	        if (Input.GetKeyDown(KeyCode.Space)){
	            Jump();
	        }
	        if (Input.GetKeyUp(KeyCode.D)){
	            Idle();
	        }
	        if (Input.GetKeyUp(KeyCode.A)){
	            Idle();
	        }
            if(Input.GetButtonDown("Fire1")){
                Shoot();
            }
	        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag.Equals("enemy")){
            // anim.ResetTrigger("jump");
            // anim.ResetTrigger("run");
            // anim.ResetTrigger("idle");
            // anim.SetTrigger("dead");
            // isDead = true;
            audio.PlayOneShot(dead);
            transform.position = respawnPoint;
        }
        if (collision.transform.tag.Equals("CheckPoint")){
            respawnPoint = collision.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
	    if (isJump){
	        anim.ResetTrigger("jump");
	        if (idMove == 0) anim.SetTrigger("idle");
	        isJump = false;
	        }	 
	    }
	    
    private void OnCollisionExit2D(Collision2D collision){
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        isJump = true;
        audio.PlayOneShot(jump);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag.Equals("coin")){
            Destroy(collision.gameObject);
            score = score + 15;
            textCoin.text = "" + score;
            audio.PlayOneShot(coin);
        }
    }

    public void MoveRight(){
        idMove = 1;
    }
    
    public void MoveLeft(){
        idMove = 2;
    }
    
    private void Move(){
        if (idMove == 1 && !isDead){
            // Move Right
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 3f, 0, 0);
            transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
        }
        if (idMove == 2 && !isDead){
            // Move Left
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 3f, 0, 0);
            transform.localScale = new Vector3(-0.13f, 0.13f, 0.13f);
        }
    }
    
    public void Jump(){
        if (!isJump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250f);
        }
    }
    
    public void Idle(){
        if (!isJump){
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }
	    idMove = 0;
    }

    void Shoot(){
        audio.PlayOneShot(shot);
        anim.SetTrigger("attack");
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

}