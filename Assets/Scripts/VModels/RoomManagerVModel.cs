using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManagerVModel : MonoBehaviour {

	// for editor purposes
	public List<RoomVModel> rooms = new List<RoomVModel>();
	public List<BuildingVModelController> buildings = new List<BuildingVModelController>();


	//Dictionarys used for ease of searching
	public Dictionary<string,RoomVModel> roomDatabase = new Dictionary<string,RoomVModel> ();
	public Dictionary<BuildingCodes,BuildingVModelController> buildingDatabase = new Dictionary<BuildingCodes,BuildingVModelController> ();
	//Multiples database, keeps track of rooms with the same number but in different buildings
	public Dictionary<string,List<RoomVModel>> multiplesRoomDic = new Dictionary<string, List<RoomVModel>>();

	public RoomVModel currentDisplayedRoom;
	public int roomsLoaded = 0;
	public GameObject roomPointerPrefab;
	[HideInInspector]
	public GameObject roomPointer;

}

public enum BuildingCodes{
	PG = 1,
	N = 2,
	BS = 3
}

