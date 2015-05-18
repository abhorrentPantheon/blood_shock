﻿using UnityEngine;
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
				//grabbedObject

				// Get the overlapObj from DetectOverlap

				if (GetComponent<DetectOverlap>().overlapObj != null) {
					Debug.Log (GetComponent<DetectOverlap>().overlapObj.name);
				}

				//DetectOverlap overlapObj = GetComponent<DetectOverlap>();
//				if (overlapObj != null) {
//					Debug.Log ("overlapObj = " + overlapObj.name);
//				}
//				if (overlapObj != null) {
//					Debug.Log ("Overlap: " + overlapObj);
//					
//				}

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
