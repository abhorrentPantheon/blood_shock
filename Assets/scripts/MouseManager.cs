using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseManager: MonoBehaviour {
	
	Rigidbody2D grabbedRB = null;
	Vector2 grabbedInitPos = Vector2.zero;

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

				grabbedRB = hit.collider.attachedRigidbody;
				grabbedInitPos = GameObject.Find(grabbedRB.name).GetComponent<objMovement>().initLoc;

				// Set reHome to false so that it doesn't conflict with other movement in update
				//GameObject.Find(grabbedRB.name).GetComponent<objMovement>().reHome = false;

			}

		}
		
		if (Input.GetMouseButtonUp(0)) {
			if (grabbedRB != null) {

				//Vector2 grabbedInitPos = grabbedRB.position;

				// Move object
				grabbedRB.velocity = Vector2.zero;
				//Debug.Log ("let go of " + grabbedRB.name);

				/* 
				 * 
				 * This sections need to detect whether socket/target is already populated, and if so, return object
				 * to initial position.
				 * 
				 */

				/*
				 * // If ovObj is a box, move it to a socket
				 * 
				 */

				// If ovObj is an arrow, move it to a target
				if (grabbedRB.name.Contains( "arrow") ) {
					// Create alias for detect overlap component
					var detOver = GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>();
					var objMov = GameObject.Find(grabbedRB.name).GetComponent<objMovement>();

					if (detOver.overlapObj != null) {
						List<string> ovList = detOver.overlapList;
						//string ovListP = string.Join("-", ovList.ToArray());

						// List comprehension to find 'target' in strings of ovList
						string ovObj = ovList.Find(listOvObj => listOvObj.Contains("target"));

						// If there's a 'target' for the object:
						if (ovObj != null ) {
							grabbedRB.position = GameObject.Find(ovObj).transform.position;
							objMov.atDest = true;
						} else {
							objMov.atDest = false;
							//Vector2 goHome = grabbedInitPos - grabbedRB.position;
							Debug.Log (grabbedInitPos - grabbedRB.position);
							//grabbedRB.velocity = grabbedInitPos - grabbedRB.position;
							//grabbedRB.velocity = Vector2.Lerp(grabbedRB.position, grabbedInitPos, Time.deltaTime);

						}
					} else {
						objMov.atDest = false;
						//grabbedRB.velocity = grabbedInitPos - grabbedRB.position;
						Debug.Log (grabbedInitPos - grabbedRB.position);

						//grabbedRB.velocity = Vector2.Lerp(grabbedRB.position, grabbedInitPos, Time.deltaTime);
					}
				}
				// null MUST come after doing something with it, else exception.
				grabbedRB = null;
				grabbedInitPos = Vector2.zero;
			}
		}
		
	}
	
	void FixedUpdate() {
		// Don't move if it's a blank box
		//if (grabbedRB != null && !grabbedRB.name.Contains("blank")) {
		if (grabbedRB != null) {
			// Make the object centre to the mouse position smoothly
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
			
			Vector2 dir = mousePos2D - grabbedRB.position;
			// move smoothly to mouse position
			grabbedRB.velocity = dir * 25;
			// Snap to mousePos2D:
			//grabbedObject.position = mousePos2D;

			/* 
			 * Fix this bit to return objects to home smoothly (rather than instant 
			 */
		}

		foreach(GameObject arw in GameObject.FindGameObjectsWithTag("arrows")) {
			var aom = arw.GetComponent<objMovement>();
			if (aom.reHome) {
				float spd = 100 * Time.deltaTime;
				arw.transform.position = Vector2.MoveTowards(arw.transform.position, aom.initLoc, spd);
			}
		}
		foreach(GameObject bxs in GameObject.FindGameObjectsWithTag("boxes")) {
			var bom = bxs.GetComponent<objMovement>();
			if (bom.reHome) {
				float spd = 100 * Time.deltaTime;
				bxs.transform.position = Vector2.MoveTowards(bxs.transform.position, bom.initLoc, spd);
			}
		}
	}
}
