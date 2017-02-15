using UnityEngine;
using System.Collections;

public class RoomVModel : MonoBehaviour {

	public string roomNum;
	public BuildingCodes buildingCode;
	public int floor;
	public Transform roomTransform;
	public GameObject roomMesh;

	public float length, width;
	public float height = 2.25f;
	public float wallThickness = 0.2f;
	public float floorThickness = 0.2f;
	public Material selectedMat, unselectedMat;
	private GameObject floor01, wall01, wall02, wall03, wall04;
	private Transform wall1Pivot, wall2Pivot, wall3Pivot, wall4Pivot;

	void Awake(){
		gameObject.name = roomNum;
		roomTransform = transform;
	}

	void Start(){
		RoomManagerController.instance.AddRoom (this);
		CreateRoom();
	}

	void Update(){
		TempUpdatePositions();
	}

	void CreateRoom(){
		floor01 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//floor01.transform.position = roomTransform.position;
		//floor01.transform.localScale = new Vector3(length, floorThickness, width);
		
		wall01 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall01.transform.position = roomTransform.position + new Vector3(0, height/2, width/2);
		//wall01.transform.localScale = new Vector3(length, height, wallThickness);
		
		wall02 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall02.transform.position = roomTransform.position + new Vector3(0, height/2, -width/2);
		//wall02.transform.localScale = new Vector3(length, height, wallThickness);
		
		wall03 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall03.transform.position = roomTransform.position + new Vector3(length/2, height/2, 0);
		//wall03.transform.localScale = new Vector3(wallThickness, height, width);
		
		wall04 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//wall04.transform.position = roomTransform.position + new Vector3(-length/2, height/2, 0);
		//wall04.transform.localScale = new Vector3(wallThickness, height, width);

		floor01.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall01.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall02.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall03.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall04.gameObject.GetComponent<Renderer>().material = unselectedMat;
	}

	public void TriggerSelect(){
		floor01.gameObject.GetComponent<Renderer>().material = selectedMat;
		wall01.gameObject.GetComponent<Renderer>().material = selectedMat;
		wall02.gameObject.GetComponent<Renderer>().material = selectedMat;
		wall03.gameObject.GetComponent<Renderer>().material = selectedMat;
		wall04.gameObject.GetComponent<Renderer>().material = selectedMat;
	}

	public void TriggerUnselect(){
		floor01.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall01.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall02.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall03.gameObject.GetComponent<Renderer>().material = unselectedMat;
		wall04.gameObject.GetComponent<Renderer>().material = unselectedMat;
	}	

	void TempUpdatePositions () {
		floor01.transform.position = roomTransform.position;
		floor01.transform.localScale = new Vector3(length-0.1f, floorThickness, width-0.1f);

		wall01.transform.position = roomTransform.position + new Vector3(0, height/2, (width/2)-wallThickness/2);
		wall01.transform.localScale = new Vector3(length, height, wallThickness);

		wall02.transform.position = roomTransform.position + new Vector3(0, height/2, (-width/2)+wallThickness/2);
		wall02.transform.localScale = new Vector3(length, height, wallThickness);

		wall03.transform.position = roomTransform.position + new Vector3((length/2)-wallThickness/2, height/2, 0);
		wall03.transform.localScale = new Vector3(wallThickness, height, width);

		wall04.transform.position = roomTransform.position + new Vector3((-length/2)+wallThickness/2, height/2, 0);
		wall04.transform.localScale = new Vector3(wallThickness, height, width);
	}
}
