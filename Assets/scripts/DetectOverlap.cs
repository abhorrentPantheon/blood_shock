using UnityEngine;
using System.Collections;
// Enable lists
using System.Collections.Generic;

public class DetectOverlap : MonoBehaviour {

	public string overlapObj = null;
	public List<string> overlapList = new List<string>();

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("Object " + this.name + " overlaps " + other.name);
		//overlapObj = other
		overlapObj = other.name;
		if (!overlapList.Contains(other.name)) {
			overlapList.Add(other.name);
		}
		//Debug.Log ("Last index: " + overlapList.Count);
		//Debug.Log ("new overlap");
	}

//	void OnTriggerStay2D (Collider2D other) {
//		Debug.Log ("Object " + other.name + " is overlapping zone");
//		//Debug.Log ("still overlapping");
//	}

	void OnTriggerExit2D (Collider2D other) {
		Debug.Log ("Object " + this.name + " no longer overlaps " + other.name);
		overlapObj = null;
		overlapList.Remove(other.name);
		//Debug.Log ("no longer overlap");
	}
}
