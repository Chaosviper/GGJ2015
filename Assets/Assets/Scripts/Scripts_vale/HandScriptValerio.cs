using UnityEngine;
using System;
using System.Collections;

public class HandScriptValerio : MonoBehaviour {

	// Class Variable
	public PlayerEnum player;
	public float axisSpeed = 1f;
	public float signX = 0f;
	public float smoothX = 0;
	public float signY = 0f;
	public float smoothY = 0;
	private float delta = 0.01f;

	// Starting setted variable
	string VerticalAxisName = ""; 
	string HorizontalAxisName = ""; 
	string InputButtonName = ""; 
	
	// Input variables
	float translationY = 0;
	float translationX = 0;
	
	// If is the key pressed the vaule became true
	bool isInteractionButtonTriggered = false;


	// Use this for initialization
	void Start () {
		if(player == PlayerEnum.Player1){
			VerticalAxisName = "Vertical1"; 
			HorizontalAxisName = "Horizontal1";
			InputButtonName = "LB"; 
		}
		else if(player == PlayerEnum.Player2){
			VerticalAxisName = "Vertical2"; 
			HorizontalAxisName = "Horizontal2";
			InputButtonName = "RB"; 
		}
	}

	// Update is called once per frame
	void Update () {

		// ** Spostamento
		if(Input.GetAxisRaw(VerticalAxisName) != 0){
			signY = Input.GetAxisRaw(VerticalAxisName);
			smoothY = 1f;
		}
		if(Input.GetAxisRaw(HorizontalAxisName) != 0){
			signX = Input.GetAxisRaw(HorizontalAxisName);
			smoothX = 1f;
		}

		translationY = Input.GetAxis(VerticalAxisName)*axisSpeed*Time.deltaTime + signY*smoothY*axisSpeed*Time.deltaTime;
		translationX = Input.GetAxis(HorizontalAxisName)*axisSpeed*Time.deltaTime + signX*smoothX*axisSpeed*Time.deltaTime;

		smoothX -= delta;
		smoothY -= delta;

		if(smoothX < 0){
			smoothX = 0;
		}
		if(smoothY < 0){
			smoothY = 0;
		}

		// *** Check dei Boundary
		bool isCollisionDetected = false;
		
		if(translationY != 0){
			if(translationY > 0 && collisionEdgeDetected[3] != 0)
				translationY = 0;
			if(translationY < 0 && collisionEdgeDetected[2] != 0)
				translationY = 0;
			
			if(translationY == 0)
				isCollisionDetected = true;
		}
		if(translationX != 0){
			if(translationX > 0 && collisionEdgeDetected[1] != 0)
				translationX = 0;
			if(translationX < 0 && collisionEdgeDetected[0] != 0)
				translationX = 0;
			
			if(translationX == 0)
				isCollisionDetected = true;
		}
		// *** End

		transform.Translate(translationX, translationY, 0);
		// ** End Spostamento

		if(Input.GetAxis(InputButtonName) > 0 && !isInteractionButtonTriggered)
			isInteractionButtonTriggered = true;

	}

	void FreePressedButton(){
		isInteractionButtonTriggered = false;
	}

	bool IsButtonPressed(){
		return isInteractionButtonTriggered;
	}

	// *************************************** BOUNDARY EVENT **************************************
	
	// Left Right Bottom Top
	int[] collisionEdgeDetected = new int[4]{ 0, 0, 0, 0 };
	
	void OnTriggerEnter(Collider other){

		if(other.tag == "Border"){
			int index =  Convert.ToInt32(other.name.Substring(0,1));
			
			collisionEdgeDetected[index] = 1;
		}
	}
	
	void OnTriggerExit(Collider other){
		
		if(other.tag == "Border"){
			int index = Convert.ToInt32(other.name.Substring(0,1));
			
			collisionEdgeDetected[index] = 0;
		}
	}
}
