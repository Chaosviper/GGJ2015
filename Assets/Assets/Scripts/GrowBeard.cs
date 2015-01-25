using UnityEngine;
using System.Collections;

public class GrowBeard : MonoBehaviour {
	public GameObject beardPatch;
	public Material clean;
	public float irritation;
	public int beard, blood;
	public bool hand, done;
	public int numpeli, maxrange;
	public Material beard1, beard2;
	
	// Use this for initialization
	void Start () {
		done=false;
		beard=0;
		blood=0;
		Vector3 temp2;
		GameObject temp;
		for(int i=0; i<transform.childCount; i++){
			temp=transform.GetChild(i).gameObject;
			beard++;
			temp.GetComponent<CutBeard>().clean=this.clean;
			temp.GetComponent<CutBeard>().beard=true;
			temp.GetComponent<CutBeard>().hand=hand;
			temp.GetComponent<CutBeard>().irritation=irritation;
			}
        Debug.Log(beard);/*
		for (int i=0; i<sizex; i++)
			for (int j=0; j<sizey; j++)
				if(Random.value>0.2){
					beard++;
					temp=(GameObject)Instantiate(beardPatch);
					temp.transform.parent=this.transform;
					temp.GetComponent<CutBeard>().clean=this.clean;
					temp.GetComponent<CutBeard>().beard=true;
					temp.GetComponent<CutBeard>().hand=hand;
					temp.GetComponent<CutBeard>().irritation=irritation;
				temp2=(new Vector3(i+transform.position.x+Random.value, transform.position.y+Random.value, j+transform.position.z+Random.value));
					temp.transform.position=temp2;
					if(Random.Range(0, 5)>2)
						temp.transform.renderer.material=beard1;
					else temp.transform.renderer.material=beard2;
				temp.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
			}else{
					temp=(GameObject)Instantiate(beardPatch);
					temp.transform.parent=this.transform;
					temp.GetComponent<CutBeard>().beard=false;
					temp.GetComponent<CutBeard>().hand=hand;
					temp.GetComponent<CutBeard>().irritation=irritation;
			temp2=(new Vector3(i+transform.position.x+Random.value, transform.position.y, j+transform.position.z+Random.value));
					temp.transform.position=temp2;
					temp.transform.renderer.material=clean;
			temp.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if(beard==0)
			done=true;
	}
}
