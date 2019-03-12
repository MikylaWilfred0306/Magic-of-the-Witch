using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicExplode : MonoBehaviour {
public float lifetime = .15f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime <=0){
			Destroy (gameObject);
		}
	}
}
