using UnityEngine;
using System.Collections;

public class InitVelocity : MonoBehaviour {
	
	public Vector3 initVel;
	public Vector3 initLoc;
	
	/* Use this for initialization */
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = initVel;
		//this.GetComponent<Transform()>.position = initLoc;
		initLoc = this.GetComponent<Transform>().position;
	}
	
	/* Update is called once per frame */
	void Update () {
		
	}
}
