using UnityEngine;
using System.Collections;

public class MartelloRotationScript : MonoBehaviour {
	public GameObject martello;
	public GameObject martelloHead;
	public HandHammerCollision handCollision;
	public GameObject chiodoObj;
	public GameObject leftHand;
	public GameObject positionX;
	public LifeController lifeController;
	public HammerLevelManager HammerLevelManager;
	public Chiodo chiodo;
	public AudioSource colpo;
	public AudioSource voce;
	private Vector3 originalScale;
	public AudioClip [] colpi;

	public bool canHit;
	public float scaleFactor;

	void Start(){
		this.canHit = true;
		this.originalScale = this.transform.localScale;
	}
	void Update () {
		if((Input.GetButtonDown("RB") || Input.GetKeyDown(KeyCode.Space)) && this.canHit){
			martello.transform.localScale = new Vector3(this.transform.localScale.x*scaleFactor,this.transform.localScale.y*scaleFactor,this.transform.localScale.z);
			this.canHit = false;
			StartCoroutine("Martella");
			float distanceChiodoX = Vector2.Distance(
														new Vector2(positionX.transform.position.x,positionX.transform.position.y),
														new Vector2(chiodoObj.transform.position.x,chiodoObj.transform.position.y));


			if(handCollision.overHand){
				this.voce.Play();
				this.colpo.clip = colpi[0];
				this.colpo.Play();
				if(lifeController.RemoveLife()<0){
					HammerLevelManager.StartCoroutine("Lose");
				}
				Debug.Log("MANO PRESA");
			}else{
				if(handCollision.overNail && distanceChiodoX < 0.9f){
					Debug.Log("CHIODO PRESO");
					this.colpo.clip = colpi[2];
					this.colpo.Play();
					chiodo.ChiodoFixed();
					HammerLevelManager.StartCoroutine ("Win");
				}else{
					this.colpo.clip = colpi[1];
					this.colpo.Play();
					Debug.Log("MANCATO!");
				}
			}
		}
	}

	IEnumerator Martella(){
		yield return new WaitForSeconds(Constants.TIMER_TEMPO_TRA_MARTELLATE);
		martello.transform.localScale = this.originalScale;
		this.canHit = true;	
	}
}
