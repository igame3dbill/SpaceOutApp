using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinImage : MonoBehaviour {

    Transform transform;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * -.5f);
	}
}
