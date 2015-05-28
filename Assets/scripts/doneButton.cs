using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class doneButton : MonoBehaviour {

	//GameObject.Find("Score").GetComponent<Text>().text = outScore.ToString();
	private Color origColor;
	private Color mouseOverColor = Color.grey;
	public int finScore = 0;

	// Use this for initialization
	void Start () {
		origColor = this.GetComponent<Renderer>().material.color;
	}

	void OnMouseEnter() {
		/* Change material when hover */
		this.GetComponent<Renderer>().material.color = mouseOverColor;
	}

	void OnMouseExit() {
		/* Change material when no more */
		this.GetComponent<Renderer>().material.color = origColor;
	}

	void OnMouseDown() {
		Debug.Log(this.GetComponent<Renderer>().material.color);
		this.finScore += finScore;
		GameObject.Find("Score").GetComponent<Text>().text = finScore.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
