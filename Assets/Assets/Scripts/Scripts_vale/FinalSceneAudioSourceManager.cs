using UnityEngine;
using System.Collections;

public class FinalSceneAudioSourceManager : MonoBehaviour {
	public AudioClip [] sounds;
	private AudioSource audiosource;

	// Use this for initialization
	void Start () {
		this.audiosource = this.GetComponent<AudioSource>();
	}


	public void OpenDoor(){
		this.audiosource.Play();
	}

	public void MyLove(){
		this.audiosource.clip = sounds[1];
		this.audiosource.Play ();
	}

	public void WhatWeDoNow(){
		this.audiosource.clip = sounds[2];
		this.audiosource.Play ();
	}
}
