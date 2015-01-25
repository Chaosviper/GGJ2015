using UnityEngine;
using System.Collections;
 

public class PlayerMovement : MonoBehaviour

   {

	public bool hand;
      private Vector3 movementVector;
      private CharacterController characterController;
      private float movementSpeed = 8;
      private float jumpPower = 15;
		float maxHandDistance=1;
	public GameObject otherHand;

 
   void Start()
   {
      characterController = GetComponent<CharacterController>();
   }

 
   void Update()
   {
		if(hand){
		if(checkHandsInversion (Input.GetAxis("Horizontal1") * movementSpeed * Time.deltaTime))
      		movementVector.x = Input.GetAxis("Horizontal1") * movementSpeed;
			else movementVector.x=0;
      	movementVector.z = Input.GetAxis("Vertical1") * movementSpeed;
		}else{
			if(checkHandsInversion (Input.GetAxis("Horizontal2") * movementSpeed* Time.deltaTime))
      	movementVector.x = Input.GetAxis("Horizontal2") * movementSpeed;
			else movementVector.x=0;
      	movementVector.z = Input.GetAxis("Vertical2") * movementSpeed;
		}
		
	if(Input.GetButtonDown("LB") || (Input.GetButtonDown("RB")))
			audio.Play();
	if(!Input.GetButton ("LB") && (!Input.GetButton("RB")))
			audio.Stop ();
		float horizontal, vertical;

		if (hand)
		{
			horizontal = Input.GetAxis("Horizontal1");
			vertical = Input.GetAxis("Vertical1");
		}
		else
		{
			horizontal = Input.GetAxis("Horizontal2");
			vertical = Input.GetAxis("Vertical2");
		}
		if (transform.position.x + Input.GetAxis("Horizontal2") * movementSpeed* Time.deltaTime <= -Constants.tutorialPosX && horizontal < 0)
		{
			movementVector.x = 0;
		}
		else if (transform.position.x + Input.GetAxis("Horizontal2") * movementSpeed* Time.deltaTime >= Constants.tutorialPosX && horizontal > 0)
		{
			movementVector.x = 0;
		}
		
		if (transform.position.z + Input.GetAxis("Vertical2") * movementSpeed*Time.deltaTime <= -Constants.tutorialPosY && vertical < 0)
		{
			movementVector.z = 0;
		}
		else if (transform.position.z + Input.GetAxis("Vertical2") * movementSpeed*Time.deltaTime >= Constants.tutorialPosY && vertical > 0)
		{
			movementVector.z = 0;
		}

    characterController.Move(movementVector * Time.deltaTime);

   }


	
	bool checkHandsInversion(float horizontalMovement)
	{
		if (hand)
		{
			if (transform.position.x +horizontalMovement + maxHandDistance >= otherHand.transform.position.x)
			{
				return false;
			}
			else return true;
		}
		else
		{
			if (transform.position.x + horizontalMovement - maxHandDistance <= otherHand.transform.position.x)
			{
				return false;
			}
			else return true;
		}
	}
}
