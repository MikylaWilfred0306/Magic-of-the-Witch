using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour {

	public GameObject[] cameraArray;

private int gameCamera = 0;
	// Use this for initialization
	void Start () {
		FocusOnCamera (gameCamera);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("t")) {
			ChangeCamera(1);
		}
		if (Input.GetKeyUp ("y")) {
			ChangeCamera(-1);
		}
			
	}
	
	
	void FocusOnCamera (int index){
		for (int i = 0; i < cameraArray.Length; i++){
			cameraArray [i].SetActive(i==index);
		}
	}
	
	void ChangeCamera (int direction){
		gameCamera += direction;
		if(gameCamera >= cameraArray.Length){
			gameCamera = 0;
		}
		if(gameCamera < 0){
			gameCamera = cameraArray.Length - 1;
		}
		FocusOnCamera (gameCamera);
	}
	
}
