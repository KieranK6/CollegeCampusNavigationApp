using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManagerController : MonoBehaviour {

	public static RoomManagerController instance;
	public RoomManagerVModel vModel;
	private RoomVModel currentRoom;



	void Awake(){

		instance = this;

		InitDatabase ();

	}

	private void InitDatabase(){

		//load building data into dic
		foreach (BuildingVModelController  building in vModel.buildings) {

			vModel.buildingDatabase.Add (building.buildingCode, building);
		}

	}

	public void AddRoom(RoomVModel r){
		//load room data into dic

		if (!vModel.roomDatabase.ContainsKey (r.roomNum)) {
			vModel.roomDatabase.Add (r.roomNum, r);
		} else {
			//this room has alreadt been added to the general List, now it and the original must be added to the multiples list
			if (!vModel.multiplesRoomDic.ContainsKey (r.roomNum)) {
				Debug.Log("Adding Multiple " + r.roomNum );
				vModel.multiplesRoomDic.Add(r.roomNum, new List<RoomVModel>());
				//dont forget to add the original
				vModel.multiplesRoomDic[r.roomNum].Add(vModel.roomDatabase[r.roomNum]);
			}
			//add the multiples
			vModel.multiplesRoomDic[r.roomNum].Add(r);
		}

		vModel.roomsLoaded ++;

	}

	public void SearchRoom(string val){

		RestoreDefaults ();
		//first check if that room is in the multiples list, if so we want to show the person a list of rooms to choose from with the building deatils attached,(which will be 
		//looked up from another dictionary using the buildingCode)
		if (vModel.multiplesRoomDic.ContainsKey (val)) {
			//populate a possible rooms list with details and present onscreen
			UserInterfaceController.instance.vModel.notificationBarTxt.text = "There are multiples of this room, choose one...";
		} else {
			//look up in the general list 
			RoomVModel room;
			if (vModel.roomDatabase.TryGetValue (val, out room)) {
				//found the room!, so now display it on screen
				//pobabaly trigger IEnumerable event to display animation etc.
				vModel.currentDisplayedRoom = room;
				currentRoom = room;
				room.TriggerSelect();
				StartCoroutine (DisplayRoom ());

			} else {
				//if there was no room found
				//let the push "room code does not exsit " to screen
				UserInterfaceController.instance.vModel.notificationBarTxt.text = "There is no room ["+val+"].";
			}

		}
	}

	IEnumerator DisplayRoom(){

		UserInterfaceController.instance.vModel.notificationBarTxt.text = "Located in " + RoomManagerController.instance.vModel.buildingDatabase[vModel.currentDisplayedRoom.buildingCode].longName;
		//move to the camera dock for that building.
		//CameraManagerController.instance.MoveToCameraPosition ((int)vModel.currentDisplayedRoom.buildingCode);
		CameraManagerController.instance.MoveToCameraPosition ((int)vModel.currentDisplayedRoom.buildingCode, vModel.currentDisplayedRoom.roomTransform);

		yield return new WaitForSeconds (1);

		//highlight the correct floor
		bool floorReached = false;
		int currentFloor = 0;
		while (!floorReached) {
			if (currentFloor == vModel.currentDisplayedRoom.floor) {
				floorReached = true;

				vModel.roomPointer = Instantiate (vModel.roomPointerPrefab) as GameObject;
				vModel.roomPointer.transform.SetParent (vModel.currentDisplayedRoom.roomTransform, false);
				vModel.roomPointer.transform.localScale = new Vector3 (2, 2, 2);

			} else {
				currentFloor++;
				vModel.buildingDatabase [vModel.currentDisplayedRoom.buildingCode].DisplayFloor (currentFloor);
				yield return new WaitForSeconds (0.5f);

			}
		}

		//TODO display other building infor in UI
	}

	public void RestoreDefaults(){
		if (vModel.roomPointer != null) {
			Destroy (vModel.roomPointer.gameObject);
			currentRoom.TriggerUnselect();
		}
		UserInterfaceController.instance.vModel.notificationBarTxt.text = "";
		UserInterfaceController.instance.vModel.searchField.text = "";
		if (vModel.currentDisplayedRoom != null) {
			vModel.buildingDatabase [vModel.currentDisplayedRoom.buildingCode].ResetBuildingDisplay();
		}
	}

}
