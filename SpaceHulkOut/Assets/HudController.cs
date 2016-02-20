using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {

	//bool EarlyWarning;

	public GameObject Warning;
	public GameObject Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WarningOn(){
		Warning.gameObject.GetComponent<HTSpriteSheet> ().enabled = true;

	}
	public void WarningOff(){
		Warning.gameObject.GetComponent<HTSpriteSheet> ().enabled = false;

	}
}
