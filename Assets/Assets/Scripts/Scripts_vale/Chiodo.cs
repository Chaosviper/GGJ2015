using UnityEngine;
using System.Collections;

public class Chiodo : MonoBehaviour {
	public void ChiodoFixed(){
		this.transform.parent = GameObject.FindGameObjectWithTag("Background").transform;
	}
}
