using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {
	public float FADE_SPEED = 0.01f;
	private bool fadeOn;

	// Use this for initialization
	void Awake () {
		this.fadeOn = true;
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.fadeOn){
			if(this.renderer.material.color.a > 0){ 
				this.renderer.material.color = new Color(this.renderer.material.color.r,
				                                            this.renderer.material.color.g,
				                                            this.renderer.material.color.b,
				                                            this.renderer.material.color.a - FADE_SPEED);
			}else{
				this.enabled = false;
			}
		}else{
			if(this.renderer.material.color.a < 1){
				this.renderer.material.color = new Color(this.renderer.material.color.r,
				                                            this.renderer.material.color.g,
				                                            this.renderer.material.color.b,
				                                            this.renderer.material.color.a + FADE_SPEED);
			}else{
				this.enabled = false;
			}
		}
	}

	public void FadeOn(){
		this.fadeOn = true;
		this.enabled = true;
	}

	public void FadeOff(){
		this.fadeOn = false;
		this.enabled = true;
	}
}
