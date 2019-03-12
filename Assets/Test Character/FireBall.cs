using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
public float shootingForce = 750f;
public Vector3 shootingDirection;
public float lifetime = 2f;
public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
			GetComponent<Rigidbody>().AddForce(shootingDirection * shootingForce);
	}
	
	// Update is called once per frame
	void Update () {
				lifetime -= Time.deltaTime;
		if(lifetime <=0){
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter (Collision collision){
		if(collision.transform.tag == "Enemy"){
			GameObject explodeObject = Instantiate (explosionPrefab);
			explodeObject.transform.position = transform.position;	
			Destroy (gameObject);			
		}
	}
}
