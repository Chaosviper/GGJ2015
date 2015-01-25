using UnityEngine;
using System.Collections;

public class HandHammerCollision : MonoBehaviour {

	public bool overHand;
	public bool overNail;

	// Use this for initialization
	void Start () {
		this.overHand = false;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Hand")){
			this.overHand = true;
		}else{
			if(other.tag.Equals("Nail")){
				this.overNail = true;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag.Equals("Hand")){
			this.overHand = false;
		}else{
			if(other.tag.Equals("Nail")){
				this.overNail = false;
			}
		}
	}
}
