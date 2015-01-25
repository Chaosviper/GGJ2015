using UnityEngine;
using System.Collections;

public class CutBeard : MonoBehaviour {
	public Material clean, blood1, blood2;
	public bool beard, hand;
	float time;
	public float irritation;
	
	// Use this for initialization
	void Start () {
		time=irritation;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("LB") || (Input.GetButtonDown("RB")))
			time=irritation;
	}
	
	void OnTriggerStay(Collider other){
		if((Input.GetButton("LB") && other.CompareTag("Razor1")) || (Input.GetButton ("RB") && other.CompareTag("Razor2"))){
			time=time-Time.deltaTime;
			if(time<=0){
				if(!beard){
					//transform.renderer.material.color=transform.renderer.material.color+new Color(0.5f,0,0);
					if(Random.Range(0, 5)>2)
						transform.renderer.material=blood1;
					else
						transform.renderer.material=blood2;
					transform.parent.GetComponent<GrowBeard>().blood++;
					audio.Play();
				}else{
					transform.renderer.material=clean;
					beard=false;
					transform.parent.GetComponent<GrowBeard>().beard--;
				}
				time=irritation;
			}
		}
			/*
		if((Input.GetButton("LB")==true) || (Input.GetButton("LR")==true)){
			time=time-Time.deltaTime;
			if(time<=0){
				if((other.CompareTag("Razor1") ) || ((other.CompareTag("Razor2"))) && beard==false)
					transform.renderer.material.color=transform.renderer.material.color+new Color(0.5f,0,0);
					transform.parent.GetComponent<GrowBeard>().blood++;
					//DO DAMAGE
				if((other.CompareTag("Razor1")) || ((other.CompareTag("Razor2"))) && beard==true){
					transform.renderer.material=clean;
					beard=false;
					transform.parent.GetComponent<GrowBeard>().beard--;
				}
				time=irritation;
			}
		}*/
	}
}
