using UnityEngine;
using System.Collections;

public class PainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if(Input.GetButtonDown("LB") && other.CompareTag("Razor1"))
			audio.Play();
		if(Input.GetButtonDown("RB") && other.CompareTag("Razor2"))
			audio.Play();
	}
}
