using UnityEngine;
using System.Collections;

public class BackgroundLeftShift : MonoBehaviour {
	public float xLeftLimit;
	// Use this for initialization
	void Start () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.right*Time.deltaTime*Constants.SPEED_BACKGROUND_LEFT);
		if(this.transform.localPosition.x < xLeftLimit){
			this.enabled = false;
		}
	}
	
	public void Enable(){
		this.enabled = true;
	}
}
