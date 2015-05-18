using UnityEngine;
using System.Collections;

public class InitVelocity : MonoBehaviour {
	
	public Vector3 initVel;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = initVel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
