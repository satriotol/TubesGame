using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer CpSpriteRenderer;
    public bool CpReached;
    // Start is called before the first frame update
    void Start()
    {
        CpSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            // CpSpriteRenderer = greenFlag;
            CpReached = true;
        }
    }
}
