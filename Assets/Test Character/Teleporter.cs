using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {

	//public Teleporter exitTeleporter;
	public float exitOffset = 5f;
	public string sceneLocation = "WitchWorld";

	void OnTriggerEnter(Collider otherCollider){
		if (otherCollider.GetComponent<Player> () != null) {
			SceneManager.LoadScene (sceneLocation);
		/*	Player player = otherCollider.GetComponent<Player> (); 
			player.setTeleported(true);
			player.transform.position = exitTeleporter.transform.position + exitTeleporter.transform.forward * exitOffset;
		*/
			
		}
	}
}
