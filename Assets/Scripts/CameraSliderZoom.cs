using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSliderZoom : MonoBehaviour {

	public Camera sceneCamera;

	/*public void UpdateCameraZoom(float zoomValue){
		//sceneCamera.gameObject.transform.position = new Vector3(sceneCamera.gameObject.transform.position.x,zoomValue,sceneCamera.gameObject.transform.position.z);
	}*/

	public void UpdateCameraZoom(float zoomValue){
		sceneCamera.fieldOfView = zoomValue;
	}

	public void UpdateCameraAngle(float angleValue){
		sceneCamera.gameObject.transform.localEulerAngles = new Vector3(angleValue, sceneCamera.gameObject.transform.localEulerAngles.y, sceneCamera.gameObject.transform.localEulerAngles.z);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
