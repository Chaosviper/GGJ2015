using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	const int KITCHEN_SCENE_INDEX = 3;

	public Sprite[] postIt;

	void Start(){
		gameObject.GetComponent<SpriteRenderer>().sprite = postIt[GameManager.HowMuchSceneDone()];
	}

	// Update is called once per frame
	void Update () {
		//TODO: Gestire todo completati

		if (Input.GetButton("Submit"))
		{
			Application.LoadLevel(KITCHEN_SCENE_INDEX+GameManager.HowMuchSceneDone());
		}
	}
}
