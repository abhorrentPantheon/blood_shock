using UnityEngine;
using System.Collections;

public class DetectOverlap : MonoBehaviour {

	public Collider2D overlapObj = null;

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Object " + other.name + " overlapped zone");
		overlapObj = other;
		//Debug.Log ("new overlap");
	}

//	void OnTriggerStay2D (Collider2D other) {
//		Debug.Log ("Object " + other.name + " is overlapping zone");
//		//Debug.Log ("still overlapping");
//	}

	void OnTriggerExit2D (Collider2D other) {
		Debug.Log ("Object " + other.name + " no longer overlaps zone");
		overlapObj = null;
		//Debug.Log ("no longer overlap");
	}
	
}
