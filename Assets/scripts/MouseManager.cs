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
				// Clicked on something with a collider
				//Debug.Log ("clicked on " + hit.collider.name);
				grabbedRB = hit.collider.attachedRigidbody;
				//grabbedInitPos = GameObject.Find(grabbedRB.name).GetComponent<InitVelocity>().initLoc;
				grabbedInitPos = GameObject.Find(grabbedRB.name).GetComponent<objMovement>().initLoc;
			}

			
		}
		
		if (Input.GetMouseButtonUp(0)) {
			if (grabbedRB != null) {

				//Vector2 grabbedInitPos = grabbedRB.position;

				// Move object
				grabbedRB.velocity = Vector2.zero;
				//Debug.Log ("let go of " + grabbedRB.name);

				// If ovObj is a box, move it to a socket
				if (grabbedRB.name.Contains( "box") ) {
					// Create alias for detect overlap component
					var detOver = GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>();
					
					if (detOver.overlapObj != null) {
						List<string> ovList = detOver.overlapList;
						//string ovListP = string.Join("-", ovList.ToArray());
						
						// List comprehension to find 'target' in strings of ovList
						string ovObj = ovList.Find(listEl => listEl.Contains("socket"));
						
						// If there's a 'target' for the object:
						if (ovObj != null ) {
							grabbedRB.position = GameObject.Find(ovObj).transform.position;
							
						} else {
							// otherwise snap back to initLoc
							grabbedRB.position = grabbedInitPos;
						}
						
						// If there's no overlap of a 'target', snap back to initLoc
					} else {
						grabbedRB.position = grabbedInitPos;
					}
				}

				/* 
				 * 
				 * This sections need to detect whether socket/target is already populated, and if so, return object
				 * to initial position.
				 * 
				 */

				// If ovObj is an arrow, move it to a target
				if (grabbedRB.name.Contains( "arrow") ) {
					// Create alias for detect overlap component
					var detOver = GameObject.Find(grabbedRB.name).GetComponent<DetectOverlap>();

					if (detOver.overlapObj != null) {
						List<string> ovList = detOver.overlapList;
						//string ovListP = string.Join("-", ovList.ToArray());

						// List comprehension to find 'target' in strings of ovList
						string ovObj = ovList.Find(listEl => listEl.Contains("target"));

						// If there's a 'target' for the object:
						if (ovObj != null ) {
							grabbedRB.position = GameObject.Find(ovObj).transform.position;

						} 
						//else {
							// otherwise snap back to initLoc
							//grabbedRB.position = grabbedInitPos;

							//Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
							//Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
							//Vector2 returnHome = grabbedRB.position - grabbedInitPos;
//							Vector2 returnHome = grabbedInitPos - grabbedRB.position;
//							Debug.Log (returnHome);
							//Vector2 returnHome = grabbedInitPos - mousePos2D;
//							grabbedRB.velocity = returnHome;// * 25;
//						}

					// If there's no overlap of a 'target', snap back to initLoc
					} 
					//else {
						//grabbedRB.position = grabbedInitPos;

						//Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
						//Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
						//Vector2 returnHome = grabbedRB.position - grabbedInitPos;
//						Vector2 returnHome = grabbedInitPos - grabbedRB.position;
//						Debug.Log (returnHome);
						//Vector2 returnHome = grabbedInitPos - mousePos2D;
//						grabbedRB.velocity = returnHome;// * 25;
//					}
				}
				// null MUST come after doing something with it, else exception.
				grabbedRB = null;
				grabbedInitPos = Vector2.zero;
			}
		}
		
	}
	
	void FixedUpdate() {
		// Don't move if it's a blank box
		if (grabbedRB != null && !grabbedRB.name.Contains("blank")) {
			
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

//			var objMov = GameObject.Find(grabbedRB.name).GetComponent<objMovement>();
//			if (!objMov.atHome) {
//				//Vector2 retHome = grabbedRB.position - grabbedInitPos;
//				Vector2 retHome = grabbedInitPos - grabbedRB.position;
//				grabbedRB.velocity = retHome * 25;
//			}
		}
	}
}
