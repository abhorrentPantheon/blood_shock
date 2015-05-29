using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathwayAAScore : MonoBehaviour {

	public int outScore = 0;
	public string outFeed = null;

	private string[] feedMaker = new string[20];

	// Seems to be something wrong with the dictionary constructor here
	//private Dictionary<GameObject, GameObject> ansCorrect = new Dictionary<GameObject, GameObject>();
	private Dictionary <GameObject, GameObject> ansCorrect = new Dictionary<GameObject, GameObject>();





//	bool goAns(string goName) {
//		GameObject.Find(goName).GetComponent<answerAssigned>().ansLock;
//	}
//	Component goOv(string goName) {
//		GameObject.Find(goName).GetComponent<detectOverlap>();
//	}
	GameObject goGet(string goName) {
		GameObject.Find (goName);
	}

	void ansCheck(string goName) {

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// socket 2 answered
	}
}
