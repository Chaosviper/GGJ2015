using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	const int KITCHEN_SCENE_INDEX = 3;
	
	// Update is called once per frame
	void Update () {
		//TODO: Gestire todo completati

		if (Input.GetButton("Submit"))
		{
			Application.LoadLevel(KITCHEN_SCENE_INDEX+GameManager.HowMuchSceneDone());
		}
	}
}
