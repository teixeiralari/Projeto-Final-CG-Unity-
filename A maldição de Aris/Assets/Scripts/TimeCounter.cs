using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using PlaneGravity;


public class TimeCounter : MonoBehaviour
{

    Text text;
    public static float timer = 13f;
    public Animator player;
    //private bool flag = true;
    //PlaneGravity plane = new PlaneGravity();
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 11f)
        {
            text.color = Color.red;
            StartCoroutine(blink());
        }

        if (timer < 0)
        {
            text.text = "Tempo: 0";
        }
        else
            text.text = "Tempo: " + Mathf.Round(timer);
        
    }
    //call this on update
    IEnumerator blink()
    {
        for (int i = 0; i < 12; i++)
        {
            //Visible initially
            text.enabled = false;        //Making invisible
            yield return new WaitForSeconds(0.5f); //for 2 secs
            text.enabled = true;        //Making invisible
            yield return new WaitForSeconds(0.5f); //for 2 secs
        }
    }

}
