using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {
public Player player;
//public Text healthText;
public GameObject[] hearts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		for (int i = 0; i < hearts.Length; i++){
			hearts[i].SetActive(i < player.health);
		}
		
		//healthText.text = "Health: " + player.health;
	}
}
