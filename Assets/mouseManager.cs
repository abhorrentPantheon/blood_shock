using UnityEngine;
using System.Collections;

public class MouseManager: MonoBehaviour {
	
	Rigidbody2D grabbedObject = null;
	//Collider2D grabbedColl = null;
	
	//	string[] ansBoxes = new string[] { 
	//		"box.label.001",
	//		"box.label.002",
	//		"box.label.003",
	//		"box.label.004",
	//		"box.label.005",
	//		"box.label.006",
	//		"box.label.007",
	//		"box.label.008",
	//		"box.label.009" 
	//	};
	//string[] blankBoxes = new string[] {"blank.000"};
	//Collider2D[] bBoxes = new Collider2D[] {Collider2D.};
	
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
				grabbedObject = hit.collider.attachedRigidbody;
				//grabbedColl = hit.collider;
				
				
			}
			
		}
		
		if (Input.GetMouseButtonUp(0)) {
			if (grabbedObject != null) {
				// Mouse position
				//Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
				
				// Move object
				grabbedObject.velocity = Vector2.zero;
				Debug.Log ("let go of " + grabbedObject.name);
				//grabbedObject
				// null MUST come after doing something with it, else exception.
				//grabbedObject.position = new Vector2 ( Mathf.Round(0.5f * mousePos2D.x),
				//                                      Mathf.Round(0.5f * mousePos2D.y));
				
				//if (grabbedObject.name.Contains("box")) {
				// snap to box locations
				
				//} 
				//if (grabbedObject.name.Contains("arrow")) {
				// snap to arrow locations
				//}
				//
				//foreach (GameObject chkObj in bBoxes) {
				//Collider2D chkObj = 
				//GameObject compObj = GameObject.Find(chkObj);
				//if (Physics2D.IsTouching(grabbedColl, chkObj) ) {
				//	grabbedObject.transform = chkObj.transform;
				//}
				//}
				
				grabbedObject = null;
				//grabbedColl = null;
			}
		}
		
	}
	
	void FixedUpdate() {
		// Don't move if it's a blank box
		if (grabbedObject != null && grabbedObject.name.Contains("blank") == false) {
			
			// Make the object centre to the mouse position smoothly
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
			
			Vector2 dir = mousePos2D - grabbedObject.position;
			
			grabbedObject.velocity = dir * 25;
			
			// Snap to mousePos2D:
			//grabbedObject.position = mousePos2D;
		}
	}
}
