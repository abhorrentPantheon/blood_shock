using UnityEngine;
using System.Collections;

public class capiExpose : MonoBehaviour {
	
	/* Create CAPI variables */
	//private static int tmpvar = GameObject.Find("button_done").GetComponent<pathwayAAScore>().outScore;
	//private int _outScore = tmpvar;
	private int _outScore = 0;
	public int oScore {
		get { return _outScore; }
		set { _outScore = value; Capi.set ( "Sim.Score", value ); }
	}
	//private string _outFeed = GameObject.Find("button_done").GetComponent<pathwayAAScore>().outFeed;
	private string _outFeed = "";
	public string oFeed {
		get { return _outFeed; }
		set { _outFeed = value; Capi.set ( "Sim.Feedback", value ); }
	}
	
	// Use this for initialization
	void Start () {

		/* Change output values */
		oScore = this.GetComponent<pathwayAAScore>().outScore;
		oFeed = this.GetComponent<pathwayAAScore>().outFeed;

		/* Allow CAPI variables to be seen */ 
		Capi.expose<int> ("Sim.Score", () => { return oScore; }, (value) => { return oScore = value; } );
		Capi.expose<string> ("Sim.Feedback", () => { return oFeed; }, (value) => { return oFeed = value; } );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
