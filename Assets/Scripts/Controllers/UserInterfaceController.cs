using UnityEngine;
using System.Collections;

public class UserInterfaceController : MonoBehaviour {

	public static UserInterfaceController instance;
	public UserInterfaceVModel vModel;

	void Awake(){
		instance = this;
	}

	void Start(){
		BackToHome ();
	}

	public void Search(){
		
		RoomManagerController.instance.SearchRoom (vModel.searchField.text);

	}

	public void BackToHome(){
		CameraManagerController.instance.MoveToCameraPosition (0);
	}
}
