using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class mouseManager: MonoBehaviour {

	public Rigidbody2D grabbedRB = null;
	/* As this is set to zero, all interactive objects will need to be on the axis z = 0. */
	private Vector2 grabbedInitPos = Vector2.zero;

	/* Function to check whether an arrow or text box are over the correct type of destination object */
	void overCorrectType ( string chkStr ) {
		
		string chkCont = null;
		
		switch ( chkStr ) {
		case "box":
			chkCont = "socket";
			break;
		case "arrow":
			chkCont = "target";
			break;
		default:
			Debug.Log("No type of object referenced. Did you click on anything?");
			break;
		}
		
		/* Create alias for components */
		var detOver = GameObject.Find(grabbedRB.name).GetComponent<detectOverlap>();
		var objMov = GameObject.Find(grabbedRB.name).GetComponent<objMovement>();
		
		/* If there's an overlap on the correct type, lock there, else go home */
		if ( detOver.overlapObj != null ) {
			List<string> ovList = detOver.overlapList;
			
			/* List comprehension to find 'target' in strings of ovList */
			string ovObjNm = ovList.Find(listOvObj => listOvObj.Contains( chkCont ) );
			var ovObj = GameObject.Find(ovObjNm);
			
			/* If there's a 'target' for the object: */
			if ( ovObjNm != null && !ovObj.GetComponent<answerAssigned>().ansLock ) {
				grabbedRB.position = GameObject.Find(ovObjNm).transform.position;
				objMov.reHome = false;
				objMov.atDest = true;
				ovObj.GetComponent<answerAssigned>().ansLock = true;
				
			} else {
				
				objMov.atDest = false;
			}
		} else {
			objMov.atDest = false;
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

		if ( Input.GetMouseButtonDown(0) ) {

			Vector2 dir = Vector2.zero;
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);

			var hc = hit.collider;
			if ( hc != null && ( hc.name.Contains( "box") || hc.name.Contains( "arrow") ) ) {
				grabbedRB = hc.attachedRigidbody;
				grabbedInitPos = GameObject.Find(grabbedRB.name).GetComponent<objMovement>().initLoc;
			}
//			if (hc != null && hc.name.Contains( "done" ) ) {
//				var oScoreTB = GameObject.Find("Score").GetComponent<Text>;
//				//oScoreTB.GetComponent<Text>().text = ""+oScoreTB.GetComponent<outputScore>().outScore;
//
//			}
		}
		
		if ( Input.GetMouseButtonUp(0) ) {

			if ( grabbedRB != null ) {

				grabbedRB.velocity = Vector2.zero;

				/* 
				 * These sections need to detect whether socket/target is already populated, and if so, return object
				 * to initial position.
				 * 
				 * If ovObj is a box, move it to a socket
				 */
				if ( grabbedRB.name.Contains( "box" ) ) {
					overCorrectType( "box" );
				}
				if (grabbedRB.name.Contains( "arrow" ) ) {
					overCorrectType( "arrow" );
				}

				/* On release of grabbed object, set ansLock to true */
				GameObject[] sckObjs = GameObject.FindGameObjectsWithTag( "sockets" );
				GameObject[] trgObjs = GameObject.FindGameObjectsWithTag( "targets" );
				var dstObjs = new GameObject[sckObjs.Length + trgObjs.Length];
				sckObjs.CopyTo(dstObjs, 0);
				trgObjs.CopyTo(dstObjs, sckObjs.Length);

				foreach (GameObject dob in dstObjs) {
					//Debug.Log (dob.name);
					if ( dob.GetComponent<detectOverlap>().overlapObj == null ) {
						dob.GetComponent<answerAssigned>().ansLock = false;
					}
				}

				/* Clear grabbedRB on letting go of mouse
				 * 
				 * null MUST come after doing something with it, else exception. */
				grabbedRB = null;
				grabbedInitPos = Vector2.zero;
			}
		}
	}
	
	void FixedUpdate() {
		/* Make the object centre to the mouse position smoothly */
		Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

		if ( grabbedRB != null ) {
			
			Vector2 dir = mousePos2D - grabbedRB.position;
			/* move smoothly to mouse position */
			grabbedRB.velocity = dir * 25;
			/* Snap to mousePos2D: */
			//grabbedObject.position = mousePos2D;
		}

		/* 
		 * Move objects back to starting position if not locked to a destination.
		 * 
		 * If this section is in Update(), it will only happen on an event.
		 */

		/* Get all box and arrow objects, concatenate into new list */
		GameObject[] boxObjs = GameObject.FindGameObjectsWithTag("boxes");
		GameObject[] arwObjs = GameObject.FindGameObjectsWithTag("arrows");
		var uieObjs = new GameObject[boxObjs.Length + arwObjs.Length];
		boxObjs.CopyTo(uieObjs, 0);
		arwObjs.CopyTo(uieObjs, boxObjs.Length);

		foreach( GameObject uie in uieObjs ) {
			var uom = uie.GetComponent<objMovement>();
			if ( !uom.atDest && uom.reHome ) {
				float spd = 100 * Time.deltaTime;
				uie.transform.position = Vector2.MoveTowards(uie.transform.position, uom.initLoc, spd);
			}
		}

	}
}