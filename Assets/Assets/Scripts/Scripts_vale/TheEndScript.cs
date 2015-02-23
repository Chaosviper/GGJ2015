using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheEndScript : MonoBehaviour {
	private Text text;
	// Use this for initialization
	void Start () {
		this.enabled = false;
		this.text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.text.color.a < 255f){
			this.text.color = new Color(this.text.color.r,this.text.color.g,this.text.color.b,this.text.color.a + Constants.SPEED_THE_END_COLOR);
		}else{
			this.enabled = false;
		}

	}

	public void Enable(){
		this.enabled = true;
	}
}
