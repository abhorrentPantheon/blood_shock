using UnityEngine;
using System.Collections;

public class answerAssigned : MonoBehaviour {

	public bool ansLock = false;

	void OnTriggerEnter2D (Collider2D other) {
		ansLock = true;
	}

	void OnTriggerExit2D (Collider2D other) {
		ansLock = false;
	}
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
