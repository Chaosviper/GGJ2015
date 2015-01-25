using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	bool alreadyDone = false;
	public Sprite sprite2;

	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Submit"))
        {
			if(!alreadyDone){
				alreadyDone = true;
				GameObject.Find("texture").GetComponent<SpriteRenderer>().sprite = sprite2;
			}
			else{
            	Application.LoadLevel(1);
			}
        }
	
	}
}
