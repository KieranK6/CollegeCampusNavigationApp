using UnityEngine;
using System.Collections;

public class RoomVModel : MonoBehaviour {

	public string roomNum;
	public BuildingCodes buildingCode;
	public int floor;
	public Transform roomTransform;

	void Awake(){
		gameObject.name = roomNum;
		roomTransform = transform; 
	}

	void Start(){
		RoomManagerController.instance.AddRoom (this);
	}
}
