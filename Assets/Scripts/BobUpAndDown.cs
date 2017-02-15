using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobUpAndDown : MonoBehaviour {

	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 untoeth;
	private float secondsForOneLength = 0.5f;
	 
	void Start()
	{
		frometh = transform.parent.position;
		untoeth = farEnd.position;
	}
	 
	void Update()
	{
		transform.position = Vector3.Lerp((transform.parent.position + new Vector3(0,2,0)), (transform.parent.position + new Vector3(0,4,0)) ,Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time/secondsForOneLength, 1f)) );
	}
}