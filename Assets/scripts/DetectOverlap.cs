using UnityEngine;
using System.Collections;

public class DetectOverlap : MonoBehaviour {

	public string overlapObj = null;

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Object " + other.name + " overlapped zone");
		//overlapObj = other
		overlapObj = other.name;
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
