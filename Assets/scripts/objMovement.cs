using UnityEngine;
using System.Collections;

public class objMovement : MonoBehaviour {

	public Vector3 initVel;
	public Vector3 initLoc;
	public bool atHome = true;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = initVel;
		//this.GetComponent<Transform()>.position = initLoc;
		initLoc = this.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (this.GetComponent<Transform>().position != initLoc) {
			atHome = false;
		}
	}
}
