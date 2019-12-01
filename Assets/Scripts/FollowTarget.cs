using UnityEngine;

public class FollowTarget : MonoBehaviour{
    // private Vector2 velocity;

    // public float smoothTimeX, smoothTimeY;

    // public GameObject player;

    // float posX, posY;

    public Transform player;
    public Transform Bg1;

    // void Start(){
    //     player = GameObject.FindGameObjectWithTag("Player");
    // }

    // void FixedUpdate(){
    //     posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

    //     if(player.transform.position.x >= gameObject.transform.position.x){
    //         if (Input.GetKey(KeyCode.D)){
    //             posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
    //         }
    //     }

    //     transform.position = new Vector3(posX, posY/4, transform.position.z);
    // }

    void LateUpdate(){
        if (player.position.x != transform.position.x && player.position.x > 0 && player.position.x < 500f){
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 0.9f);
        }
        Bg1.transform.position = new Vector2(transform.position.x * 1.0f, Bg1.transform.position.y);
    }
}