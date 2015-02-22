using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {
	public GameObject [] hearts;
	private int lifeIndex = 2;

	public Sprite heartLoss;
	public Sprite heartOk;

	public int RemoveLife(){
		if(lifeIndex>-1){
			hearts[lifeIndex].SetActive(false);
			lifeIndex--;

		}
		return lifeIndex;
	}

	public void Reset(){
		foreach(GameObject heart in hearts){
			heart.GetComponent<Image>().enabled = heartOk;
			lifeIndex = 2;
		}
	}

	public void DisableAll(){
		for(int i = 0; i<3; i++){
			hearts[i].SetActive(false);
		}
	}
}
