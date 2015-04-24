﻿using UnityEngine;
using System.Collections;

public class OmniController : MonoBehaviour {

	private AudioSource _0deg;
	private AudioSource _90deg;
	private AudioSource _180deg;
	private AudioSource _270deg;

	public AudioClip clipIn0;
	public AudioClip clipIn90;
	public AudioClip clipIn180;
	public AudioClip clipIn270;
	public GameObject myCamera;
	public float vol = 100.0f;


	// Use this for initialization
	void Start () {
		vol = vol/100.0f;

		_0deg = new AudioSource ();
		_90deg = new AudioSource ();
		_180deg = new AudioSource ();
		_270deg = new AudioSource ();

		_0deg = gameObject.AddComponent("AudioSource") as AudioSource;
		_90deg = gameObject.AddComponent("AudioSource") as AudioSource;
		_180deg = gameObject.AddComponent("AudioSource") as AudioSource;
		_270deg = gameObject.AddComponent("AudioSource") as AudioSource;

		_0deg.clip = clipIn0;
		_90deg.clip = clipIn90;
		_180deg.clip = clipIn180;
		_270deg.clip = clipIn270;

		_0deg.volume = 0.0f;
		_90deg.volume = 0.0f;
		_180deg.volume = 0.0f;
		_270deg.volume = 0.0f;

		_0deg.panLevel = 0.0f;
		_90deg.panLevel = 0.0f;
		_180deg.panLevel = 0.0f;
		_270deg.panLevel = 0.0f;

		_0deg.loop = true;
		_90deg.loop = true;
		_180deg.loop = true;
		_270deg.loop = true;





	}

	public void sound(bool play) {
		if (play) {
			_0deg.Play ();
			_90deg.Play ();
			_180deg.Play ();
			_270deg.Play ();
		} else {
			_0deg.Stop ();
			_90deg.Stop ();
			_180deg.Stop ();
			_270deg.Stop ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float azimuth = myCamera.transform.eulerAngles.y;
		float azimuthRad = azimuth * Mathf.Deg2Rad;

		if (azimuth <= 90.0f) 
		{
			_0deg.volume = Mathf.Cos (azimuthRad) * vol;
			_90deg.volume = Mathf.Sin (azimuthRad) * vol;
			_180deg.volume = 0.0f;
			_270deg.volume = 0.0f;
		}
		else if (azimuth > 90.0f && azimuth <= 180.0f) 
		{
			_0deg.volume = 0.0f;
			_90deg.volume = Mathf.Cos (azimuthRad - Mathf.PI/2.0f) * vol;
			_180deg.volume = Mathf.Sin (azimuthRad - Mathf.PI/2.0f) * vol;
			_270deg.volume = 0.0f;
		} 
		else if (azimuth > 180.0f && azimuth <= 270.0f) 
		{
			_0deg.volume = 0.0f;
			_90deg.volume = 0.0f;
			_180deg.volume = Mathf.Cos (azimuthRad - Mathf.PI) * vol;
			_270deg.volume = Mathf.Sin (azimuthRad - Mathf.PI) * vol;
		}
		else if (azimuth > 270.0f && azimuth <= 360.0f) 
		{
			_0deg.volume = Mathf.Sin (azimuthRad - Mathf.PI - Mathf.PI/2.0f) * vol;
			_90deg.volume = 0.0f;
			_180deg.volume = 0.0f;
			_270deg.volume = Mathf.Cos (azimuthRad - Mathf.PI - Mathf.PI/2.0f) * vol;
		}
	}
}
