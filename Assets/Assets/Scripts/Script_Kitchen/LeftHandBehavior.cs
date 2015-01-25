using UnityEngine;
using System.Collections;

public class LeftHandBehavior : MonoBehaviour {
	
	HandScript leftHandMovementScript;
	GameObject objectToCut;

	bool isBusy;
	
	// Use this for initialization
	void Start () {
		leftHandMovementScript = transform.GetComponent<HandScript>();
		objectToCut = transform.GetChild(0).gameObject;
		objectToCut.gameObject.SetActive(false);

		isBusy = false;
	}


	void OnTriggerStay(Collider other){
		if(other.tag == "CookingObj"){
			if(leftHandMovementScript.IsButtonPressed() && !isBusy){
				// Setto l'oggetto come figlio
				objectToCut.SetActive(true);
				// Lo setto occupato
				isBusy = true;
				// Distruggo il placeholder
				GameObject.Destroy(other.gameObject);
			}
		}
	}

	public void SetObjectToCut(GameObject newGO){
		objectToCut = newGO;
	}

	public void SetNotBusy(){
		isBusy = false;
	}
}
