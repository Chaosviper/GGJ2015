using UnityEngine;
using System.Collections;

public static class GameManager {

	static int score=0;

	static int ToDoDone = 0;

	public static void IncrementScore(int scorePoints){
		score += scorePoints;

		Debug.Log("Actual Score: "+ score);
	}

	public static int GetTotalScore(){
		return score;
	}

	public static void DoneAnotherScene(){
		ToDoDone++;
	}

	public static int HowMuchSceneDone(){
		return ToDoDone;
	}
}
