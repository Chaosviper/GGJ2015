using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	//public GrowBeard destra, sinistra;
	public GrowBeard unica;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(unica.done){
			//Debug.Log ("Bravo, hai perso solo "+unica.blood+" millilitri di sangue! E' un buon risultato. Suppongo. Sicuramente avresti potuto fare meglio.");
			Application.LoadLevel(2);
		}
	
	}
}
