using UnityEngine;
using System.Collections;

public class VegetablePiecesScript : MonoBehaviour {

	const int MAX_DISTANCE = 2;
	Vector3 OldPos;
	Vector3 ToReachPos;
	Vector3 deltaVector;

	float distance;
	float startTime;
	float speed =10;

	// Use this for initialization
	void Start () {
		int randomAngle = Random.Range(-60,61);

		distance = Random.value*MAX_DISTANCE + 1;

		float cos = Mathf.Cos(randomAngle*Mathf.Deg2Rad);
		float sin = Mathf.Sin(randomAngle*Mathf.Deg2Rad);

		float deltaX = cos*distance;
		float deltaY = sin*distance;

		Transform parentSaved = transform.parent; // <-- Workaround
		transform.parent = null; // <-- Workaround

		deltaVector = new Vector3(deltaX, deltaY, transform.position.z);

		transform.parent = parentSaved; // <-- Workaround

		enabled = false;
	}

	int i=0;

	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / distance;
		transform.position = Vector3.Lerp(OldPos, ToReachPos, fracJourney);
	}

	public void Enable(){
		enabled = true;

		OldPos = transform.position;
		ToReachPos = OldPos + deltaVector;

		Debug.Log("Starting Point: " + OldPos);
		Debug.Log("End Point: " + ToReachPos);

		startTime = Time.time;
	}

	public void Disable(){
		enabled = false;
	}
}
