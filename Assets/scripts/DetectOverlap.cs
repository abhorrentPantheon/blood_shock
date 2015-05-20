using UnityEngine;
using System.Collections;
// Enable lists
using System.Collections.Generic;

public class DetectOverlap : MonoBehaviour {

	public string overlapObj = null;
	public List<string> overlapList = new List<string>();

	void OnTriggerEnter2D (Collider2D other) {
		//Debug.Log ("Object " + this.name + " overlaps " + other.name);

		//overlapObj = other
		overlapObj = other.name;
		if (!overlapList.Contains(other.name)) {
			overlapList.Add(other.name);
		}
		//Debug.Log ("Last index: " + overlapList.Count);
		//Debug.Log ("new overlap");
//		if (overlapList.Count != 0) {
//			string ovListP = string.Join( "-", overlapList.ToArray() );
//			Debug.Log ("List: " +  ovListP);
//		}
	}

//	void OnTriggerStay2D (Collider2D other) {
//		Debug.Log ("Object " + other.name + " is overlapping zone");
//		//Debug.Log ("still overlapping");
//	}

	void OnTriggerExit2D (Collider2D other) {
		overlapList.Remove(other.name);
		//Debug.Log ("no longer overlap");
	
		//Debug.Log ("Object " + this.name + " no longer overlaps " + other.name);
		if (overlapList.Count == 0) {
			overlapObj = null;
			//Debug.Log ("overlapList count == 0");
		} else {
			//Debug.Log ("Length: " + overlapList.Count);
			// List is zero-indexed:
			//Debug.Log ("list[count]: " + overlapList[overlapList.Count - 1 ]);
			overlapObj = overlapList[overlapList.Count - 1];
		}
	}
}
