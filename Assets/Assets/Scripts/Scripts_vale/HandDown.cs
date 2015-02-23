using UnityEngine;
using System.Collections;

public class HandDown : MonoBehaviour {
	public float yDownLimit;
	// Use this for initialization
	void Start () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.down*Time.deltaTime*Constants.SPEED_HAND_DOWN);
		if(this.transform.localPosition.y < yDownLimit){
			this.enabled = false;
		}
	}

	public void Enable(){
		this.enabled = true;
	}
}
