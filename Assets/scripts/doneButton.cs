using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class doneButton : MonoBehaviour {

	//GameObject.Find("Score").GetComponent<Text>().text = outScore.ToString();
	private Color origColor;
	private Color mouseOverColor = new Color( 0.93f, 0.93f, 0.93f);
	public bool endSim = false;

	/* Have a locally locked thing to hold the mutable value */
	int _finScore;
	public int finScore {
		get { return _finScore; }
		set { _finScore = value; Capi.set("Done.FinScore", value); }
	}

	string _feedBack;
	public string feedBack {
		get { return _feedBack; }
		set { _feedBack = value; Capi.set("Done.FeedBack", value); }
	}

	// Use this for initialization
	void Start () {
		finScore = 0;
		origColor = this.GetComponent<Renderer>().material.color;
	}

	void OnMouseEnter() {
		/* Change material when hover */
		if (!endSim) {
			this.GetComponent<Renderer>().material.color = mouseOverColor;
		}
	}

	void OnMouseExit() {
		/* Change material back when no more */
		this.GetComponent<Renderer>().material.color = origColor;
	}

	void OnMouseDown() {
//		Debug.Log(this.GetComponent<Renderer>().material.color);
//		finScore++ ;
//		GameObject.Find("Score").GetComponent<Text>().text = finScore.ToString();

		/* Find which are in the correct positions, and if they are, add one to the score 
		 * 
		 * Add a field to arrows/boxes to say in/correct? Or to targets/sockets?
		 */



		/* Stop time - this locks all objects to current location */
		Time.timeScale = 0;
		endSim = true;
	}

	// Update is called once per frame
	void Update () {

	}
}
