using UnityEngine;
using System.Collections;

public class CameraManagerController : MonoBehaviour {

	public CameraManagerVModel vModel;
	public static CameraManagerController instance;

	public void MoveToCameraPosition(int index, Transform roomTransform){
		if (index == 0) {
			UserInterfaceController.instance.vModel.backButton.SetActive (false);
		} else {
			UserInterfaceController.instance.vModel.backButton.SetActive (true);
		}

		//vModel.sceneCamera.transform.LookAt(roomTransform);

		Vector3 moveTo = roomTransform.position+new Vector3(0,111,0);
		moveTo = new Vector3(moveTo.x, moveTo.y, vModel.cameraPositions [index].position.z);
		iTween.MoveTo (vModel.sceneCamera.gameObject, moveTo, 2);

		Vector3 rotateTo = vModel.cameraPositions [index].rotation.eulerAngles;
		rotateTo = new Vector3(vModel.sceneCamera.gameObject.transform.rotation.eulerAngles.x, rotateTo.y, rotateTo.z);
		iTween.RotateTo (vModel.sceneCamera.gameObject, rotateTo, 2);

		StartCoroutine (PointAtRoom(vModel.sceneCamera.gameObject, roomTransform));
	}

	public void MoveToCameraPosition(int index){
		if (index == 0) {
			UserInterfaceController.instance.vModel.backButton.SetActive (false);
		} else {
			UserInterfaceController.instance.vModel.backButton.SetActive (true);
		}
		iTween.MoveTo (vModel.sceneCamera.gameObject, vModel.cameraPositions [index].position, 2);
		iTween.RotateTo (vModel.sceneCamera.gameObject, vModel.cameraPositions [index].rotation.eulerAngles, 1);

	}

	void Awake(){
		instance = this;
	}

	IEnumerator PointAtRoom(GameObject sceneCamera, Transform roomTransform){

		yield return new WaitForSeconds (1.1f);
		//sceneCamera.transform.LookAt(roomTransform);
		iTween.LookTo (sceneCamera.gameObject, roomTransform.position, 2);

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

