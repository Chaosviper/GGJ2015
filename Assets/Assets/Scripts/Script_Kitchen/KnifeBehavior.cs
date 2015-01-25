using UnityEngine;
using System.Collections;

public class KnifeBehavior : MonoBehaviour {

	GameObject gameObjHitted = null;
	
//	void OnTriggerEnter(Collider other){
//		if(gameObjHitted == null){
//			if(other.tag == "LHand" || other.tag == "CookingObj"){
//				gameObjHitted = other.gameObject;
//			}
//		}
//	}
//	

	void OnTriggerStay(Collider other){
		if(other.tag == "LHand" || other.tag == "CookingObj"){
			gameObjHitted = other.gameObject;
		}
	}

	// Questo metodo sostituisce il late update
	void OnTriggerExit(Collider other){
		if(other.tag == "LHand" || other.tag == "CookingObj"){
			gameObjHitted = null;
		}
	}

	public GameObject GetGameObjHitted(){
		return gameObjHitted;
	}
}
