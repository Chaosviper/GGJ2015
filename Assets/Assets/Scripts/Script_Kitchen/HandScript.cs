using UnityEngine;
using System.Collections;
using System;

public class HandScript : MonoBehaviour {

	// Class Variable
	public PlayerEnum player;
	private int axisSpeed = 10;
	private int tremorSpeedY = 7;
	private int tremorSpeedX = 20;

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
		// If it isn't the right hand, reset the button clicked
		if(player != PlayerEnum.Player2)
			isInteractionButtonTriggered = false;

		// ** Spostamento
		translationY = Input.GetAxis(VerticalAxisName)*axisSpeed*Time.deltaTime;
		translationX = Input.GetAxis(HorizontalAxisName)*axisSpeed*Time.deltaTime;

		// *** Delta error
		translationX += UnityEngine.Random.Range(-1,2)*UnityEngine.Random.value*tremorSpeedX*Time.deltaTime;
		translationY += UnityEngine.Random.Range(-1,2)*UnityEngine.Random.value*tremorSpeedY*Time.deltaTime;
		// *** End
		
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

	public void FreePressedButton(){
		isInteractionButtonTriggered = false;
	}

	public bool IsButtonPressed(){
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
