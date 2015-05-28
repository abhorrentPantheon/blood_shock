using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class outputScore : MonoBehaviour {

	public int outScore = 0;
	public string outFdbk = null;
	public GameObject grabRB = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if ( Input.GetMouseButtonDown(0) ) {
			//var grabRB = GameObject.Find( "_uberScripts" ).GetComponent<mouseManager>().grabbedRB;
			//Debug.Log(grabRB.name);
			if ( grabRB != null ) {
				if (grabRB.name == "button_done") {
					outScore = +outScore ;
					GameObject.Find("Score").GetComponent<Text>().text = outScore.ToString();
					Debug.Log ( outScore.ToString());
				}
			}
		//}
	}
}
