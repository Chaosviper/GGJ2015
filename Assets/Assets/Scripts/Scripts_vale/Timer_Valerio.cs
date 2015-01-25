using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer_Valerio : MonoBehaviour {
	public Text text;
	public float time;
	public HammerLevelManager hammerLevelManager;
	// Use this for initialization
	void Awake () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		int seconds = (int)time % 60;
		if (time>0){
			this.text.text = seconds+"";
		}else{
			this.text.text = 0f+"";
			hammerLevelManager.SpegniLuce();
		}

	}


	public void Reset(){
		this.text.text = "";
		this.enabled = false;
	}

	public void CountDown(){
		this.time = 10;
		this.text.text = time+"";
		StartCoroutine("MoreTime");
	}

	IEnumerator MoreTime(){
		yield return new WaitForSeconds(0.5f);
		this.enabled = true;
	}
}
