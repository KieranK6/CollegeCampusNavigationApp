using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingVModelController : MonoBehaviour {

	public BuildingCodes buildingCode;
	public Text buildinglabel;
	public FloorVModelController[] floors;
	public int currentDisplayedFloor = 0;
	public string longName;
	public string description;

	public void Start(){
		buildinglabel.text = longName;
		ResetBuildingDisplay ();
	}

	public void DisplayFloor(int index){
		//TODO Do this with a nice fade animation
		currentDisplayedFloor = index;
		floors [index].floorCanvasGroup.alpha = 1;

		try{
			floors [index].GetComponent<MoveFloorScript>().enabled = true;
		}
		catch{}
	}

	public void ResetBuildingDisplay(){
		for (int i = 1; i < floors.Length; i++) {
			floors [i].floorCanvasGroup.alpha = 1;
		}
		currentDisplayedFloor = 1;
	}

	//TODO  fade in and fade out floors when in use and when not in use.


}
