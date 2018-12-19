using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour {

    public Texture _level3Background; //image do menu inicial

    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _level3Background);    
    }
}
