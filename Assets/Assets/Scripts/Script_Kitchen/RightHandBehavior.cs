using UnityEngine;
using System.Collections;

public class RightHandBehavior : MonoBehaviour {

	HandScript rightHandMovementScript;
	KnifeBehavior knifeEventScript;

	bool animationStarted= false;
	Vector3 animationScaleStep = new Vector3(1f,1f, 0f);
	int scaleDirection = 0;

	LifeController lifeController;

	public static int RemaningLife = 2; // <-- e' static perche' sono le 5.07 e ho sonno e non ho voglia di pensarci

	// Use this for initialization
	void Start () {
		rightHandMovementScript = transform.GetComponent<HandScript>();
		knifeEventScript = transform.GetComponentInChildren<KnifeBehavior>();

		// Utile per il life manager
		lifeController = GameObject.Find("Canvas").GetComponent<LifeController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rightHandMovementScript.IsButtonPressed() && !animationStarted){
			animationStarted = true;
			scaleDirection = -1;
		}

		if(animationStarted){
			transform.localScale += animationScaleStep*Time.deltaTime*scaleDirection;

			if(transform.localScale.x <= 0.5f){
				transform.localScale = new Vector3(0.5f, 0.5f, 1);
				scaleDirection = 1;

				// Recupera l'oggetto che e' al momento sul collider del knife
				ResolveCut(knifeEventScript.GetGameObjHitted());
			}
			else if(transform.localScale.x >= 0.6f){
				transform.localScale = new Vector3(0.6f, 0.6f, 1);
				rightHandMovementScript.FreePressedButton();
				animationStarted = false;
			}
		}
	}

	void ResolveCut(GameObject gameObjHitted){

		if(gameObjHitted == null){
			// Play the audio sound
			gameObject.GetComponents<AudioSource>()[0].Play();
			Debug.Log("Nothing happened");
			return;
		}

		if(gameObjHitted.tag == "CookingObj"){
			if(gameObjHitted.transform.parent != null){
				// Play the audio sound
				gameObject.GetComponents<AudioSource>()[1].Play();
				// Se e' un cookingObj ed e' figlio di qualcuno (quindi della mano sinistra)..
				gameObjHitted.GetComponent<CutObjectResolver>().ResolveCut();
			}
		}
		else{ //.. Else is the hand
			Debug.Log("Hitted: " + gameObjHitted.name);

			// Play Scream sound
			gameObject.GetComponents<AudioSource>()[2].Play();


			RemaningLife = lifeController.RemoveLife();

			if(RemaningLife < 0){
				// TODO: SCONFITTA!!!

				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

}
