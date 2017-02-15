using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConstructor : MonoBehaviour {

	public float length, width;
	public float height = 2.25f;
	public float wallThickness = 0.2f;
	public float floorThickness = 0.2f;
	public Transform pivot;
	public Material selectedMat, unselectedMat;
	public bool selected;
	private GameObject floor, wall01, wall02, wall03, wall04;
	private Transform wall1Pivot, wall2Pivot, wall3Pivot, wall4Pivot;

	// Use this for initialization
	void Start () {
		pivot = transform;
		CreateRoom();
		if(selected)
			TriggerSelect();
	}


	void CreateRoom(){
		floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//floor.transform.position = pivot.position;
		//floor.transform.localScale = new Vector3(length, floorThickness, width);
		
		wall01 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall01.transform.position = pivot.position + new Vector3(0, height/2, width/2);
		//wall01.transform.localScale = new Vector3(length, height, wallThickness);
		
		wall02 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall02.transform.position = pivot.position + new Vector3(0, height/2, -width/2);
		//wall02.transform.localScale = new Vector3(length, height, wallThickness);
		
		wall03 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall03.transform.position = pivot.position + new Vector3(length/2, height/2, 0);
		//wall03.transform.localScale = new Vector3(wallThickness, height, width);
		
		wall04 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall04.transform.position = pivot.position + new Vector3(-length/2, height/2, 0);
		//wall04.transform.localScale = new Vector3(wallThickness, height, width);
	}
	
	// Update is called once per frame
	void Update () {
		floor.transform.position = pivot.position;
		floor.transform.localScale = new Vector3(length, floorThickness, width);

		wall01.transform.position = pivot.position + new Vector3(0, height/2, (width/2)-wallThickness/2);
		wall01.transform.localScale = new Vector3(length, height, wallThickness);

		wall02.transform.position = pivot.position + new Vector3(0, height/2, (-width/2)+wallThickness/2);
		wall02.transform.localScale = new Vector3(length, height, wallThickness);

		wall03.transform.position = pivot.position + new Vector3((length/2)-wallThickness/2, height/2, 0);
		wall03.transform.localScale = new Vector3(wallThickness, height, width);

		wall04.transform.position = pivot.position + new Vector3((-length/2)+wallThickness/2, height/2, 0);
		wall04.transform.localScale = new Vector3(wallThickness, height, width);
	}

	public void TriggerSelect(){
		floor.gameObject.GetComponent<Renderer>().material = selectedMat;
	}

	public void TriggerUnselect(){
		floor.gameObject.GetComponent<Renderer>().material = unselectedMat;
	}	
}
