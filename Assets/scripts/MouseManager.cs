using UnityEngine;
using System.Collections;

public class MouseManager: MonoBehaviour {
	
	Rigidbody2D grabbedRB = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			// What is clicked on?
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
			
			Vector2 dir = Vector2.zero;
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);
			//Debug.Log (hit);
			
			//if (hit != null && hit.collider != null) {
			if (hit.collider != null) {
				// Clicked on something with a collider
				Debug.Log ("clicked on " + hit.collider.name);
				grabbedRB = hit.collider.attachedRigidbody;

			}
			
		}
		
		if (Input.GetMouseButtonUp(0)) {
			if (grabbedRB != null) {

				// Move object
				grabbedRB.velocity = Vector2.zero;
				Debug.Log ("let go of " + grabbedRB.name);

				// Get the overlapObj from DetectOverlap
				// If ovObj is a box, move it to a socket
				if (grabbedRB.name.Contains( "box") ) {
					if (GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>().overlapObj != null) {
						string ovObj = GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>().overlapObj;
						if (ovObj.Contains ("socket") ) {
							grabbedRB.position = GameObject.Find(ovObj).transform.position;
						} 
					}
				}

				/* 
				 * 
				 * These sections need to detect whether socket/target is already populated, and if so, return object
				 * to initial position.
				 * 
				 */

				// If ovObj is an arrow, move it to a target
				if (grabbedRB.name.Contains( "arrow") ) {
					if (GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>().overlapObj != null) {
						string ovObj = GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>().overlapObj;
						if (ovObj.Contains ("target") ) {
							grabbedRB.position = GameObject.Find(ovObj).transform.position;
						} 
					}
				}
				// null MUST come after doing something with it, else exception.
				grabbedRB = null;
			}
		}
		
	}
	
	void FixedUpdate() {
		// Don't move if it's a blank box
		if (grabbedRB != null && grabbedRB.name.Contains("blank") == false) {
			
			// Make the object centre to the mouse position smoothly
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
			
			Vector2 dir = mousePos2D - grabbedRB.position;

			// move smoothly to mouse position
			grabbedRB.velocity = dir * 25;

			// Snap to mousePos2D:
			//grabbedObject.position = mousePos2D;
		}
	}
}
