using UnityEngine;
using System.Collections;

public class VegetablesController : CutObjectResolver  {

	public Stack pices; 

	const int SINGLE_LIFE_POINTS = 400;

	static int objectCompletlyCutted;

	Vector3 CHILD_OBJ_POSITION = new Vector3(3.75f, 1.48f, -0.6f);

	void Awake(){
		pices = new Stack(5);
		for(int i = 2; i<7; i++){
			VegetablePiecesScript findedGameobject = transform.FindChild(""+i).gameObject.GetComponent<VegetablePiecesScript>();
			pices.Push(findedGameobject);
		}

		objectCompletlyCutted = 0;
	}

	public override void ResolveCut(){

		VegetablePiecesScript poppato = pices.Pop() as VegetablePiecesScript;
		poppato.transform.parent = null;
		poppato.Enable();

		BoxCollider myColliderToFix = this.GetComponent<BoxCollider>();
		myColliderToFix.center += new Vector3(-0.17f,0f,0f);
		myColliderToFix.size -= new Vector3(0.34f,0f,0f);

		Debug.Log("Hitted: " + poppato.name);

		if(pices.Count <= 0){
			objectCompletlyCutted++;

			if(objectCompletlyCutted >= 3){
				GameManager.IncrementScore(SINGLE_LIFE_POINTS*(RightHandBehavior.RemaningLife+1));

				Debug.Log("YOU WIN!!!!!! - Points: " + GameManager.GetTotalScore());

				GameManager.DoneAnotherScene();
				Application.LoadLevel(2);

				return;
			}

			GameObject newVegetables = GameObject.Find("Sedano_" + (objectCompletlyCutted + 1));
			newVegetables.transform.parent = transform.parent;
			newVegetables.transform.localPosition = CHILD_OBJ_POSITION;
			transform.GetComponentInParent<LeftHandBehavior>().SetObjectToCut(newVegetables);
			transform.GetComponentInParent<LeftHandBehavior>().SetNotBusy();

			for(int i = 2; i<7; i++){
				VegetablePiecesScript findedGameobject = newVegetables.transform.FindChild(""+i).gameObject.GetComponent<VegetablePiecesScript>();
				pices.Push(findedGameobject);
			}

			newVegetables.SetActive(false);

			GameObject.Destroy(gameObject);
			Debug.Log(newVegetables);

		}

	}
}
