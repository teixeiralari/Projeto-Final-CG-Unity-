using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGravity : MonoBehaviour {

    public Rigidbody plane;
    private bool flag = true;


    // Use this for initialization
    void Start () {
        plane = GetComponent<Rigidbody>();
        plane.useGravity = true;
        plane.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
