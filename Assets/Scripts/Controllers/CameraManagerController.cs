using UnityEngine;
using System.Collections;

public class CameraManagerController : MonoBehaviour {

	public CameraManagerVModel vModel;
	public static CameraManagerController instance;

	public void MoveToCameraPosition(int index){
		if (index == 0) {
			UserInterfaceController.instance.vModel.backButton.SetActive (false);
		} else {
			UserInterfaceController.instance.vModel.backButton.SetActive (true);
		}
		iTween.MoveTo (vModel.sceneCamera.gameObject, vModel.cameraPositions [index].position, 2);
		iTween.RotateTo (vModel.sceneCamera.gameObject, vModel.cameraPositions [index].rotation.eulerAngles, 2);
	}

	void Awake(){
		instance = this;
	}
		

	/*
	//For Testing...REMOVE LATER
	void Update(){
		if (Input.GetKey (KeyCode.H)) {
			MoveToCameraPosition (0);
		} else if (Input.GetKey (KeyCode.X)) {
			MoveToCameraPosition (1);
		}else if (Input.GetKey (KeyCode.Y)) {
			MoveToCameraPosition (2);
		}else if (Input.GetKey (KeyCode.Z)) {
			MoveToCameraPosition (3);
		}
	}
	*/
		
}

