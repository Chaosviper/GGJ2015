using UnityEngine;
using System.Collections;

public class HammerLevelManager : MonoBehaviour {
	//-------------------------PUBLIC_GAMEOBJ
	public FadeController fader;
	public GameObject ManoDestra;
	public GameObject ManoSinistra;
	public Timer_Valerio timer;
	public LifeController life;
	public Light light;
	public GameObject fiamma;

	//-------------------------PRIVATE_VAR
	private Vector3 ManoDestraOriginalPos;
	private Vector3 ManoSinistraOriginalPos;

	// Use this for initialization
	void Start () {
		this.ManoDestraOriginalPos = this.ManoDestra.transform.position;
		this.ManoSinistraOriginalPos = this.ManoSinistra.transform.position;
		this.fader.FadeOn();
		this.light.intensity = 3.1f;
		StartCoroutine("AvvioTimer");
	}

	private void Reset(){
		this.ManoDestra.transform.position = this.ManoDestraOriginalPos;
		this.ManoSinistra.transform.position = this.ManoSinistraOriginalPos;
		this.fader.FadeOn();
		this.light.intensity = 3.1f;
		this.fiamma.SetActive(true);
		StartCoroutine("AvvioTimer");
	}

	public void SpegniLuce(){
		this.light.intensity = 0f;
		this.fiamma.SetActive(false);
		StartCoroutine("Lose");
	}

	IEnumerator AvvioTimer(){
		yield return new WaitForSeconds(0.8f);
		this.timer.CountDown();
	}

	IEnumerator Lose(){
		this.fader.FadeOff();
		this.timer.Reset();
		yield return new WaitForSeconds(2f);
		this.Reset();
		this.life.Reset();
	}

	IEnumerator Win(){
		Debug.Log("Win");
		this.timer.Reset();
		this.life.DisableAll();
		yield return new WaitForSeconds(2f);
		Application.Quit();
	}

}
