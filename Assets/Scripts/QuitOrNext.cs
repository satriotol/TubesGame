﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class QuitOrNext : MonoBehaviour 
{
    public int index;
    // public string levelName;
    // public string NameScene = ""
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(index);
        }
    }

}
