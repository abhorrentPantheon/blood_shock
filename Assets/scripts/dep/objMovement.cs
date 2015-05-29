using UnityEngine;
using System.Collections;

public class objMovement : MonoBehaviour {

	public Vector3 initVel;
	public Vector3 initLoc;
	public bool atHome = true;
	public bool atDest = false;
	public bool reHome = false;
	
	/* Use this for initialization */
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = initVel;
		initLoc = this.GetComponent<Transform>().position;
	}
	
	/* Update is called once per frame */
	void Update () {
		if ( Input.GetMouseButtonUp(0) ) {
			if (!this.atHome || ! this.atDest) {
				this.reHome = true;
			}
		}
	}

	void FixedUpdate() {
		if (this.GetComponent<Transform>().position != initLoc) {
			atHome = false;
		} else {
			atHome = true;
			reHome = false;
		}
	}
}
