using UnityEngine;
using System.Collections;

public class Tremor : MonoBehaviour {
    Transform myTransform;  
	//Più è grande tremorValue più trema.
	public float tremorValue=5;
	
	// Use this for initialization
	void Start () {
		myTransform=this.transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tremorPos=new Vector3(Random.Range(-1,2)*tremorValue*Time.deltaTime,Random.Range(-1,2)*tremorValue*Time.deltaTime,0);
		myTransform.position+= tremorPos;
	}
}
