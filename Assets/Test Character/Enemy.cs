using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int health = 1;
	public GameObject explosionPrefab;
	public virtual void Hurt (){
		health -= 1;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter (Collider otherCollision){
		if (otherCollision.GetComponent<Sword> () != null){
			if (otherCollision.GetComponent<Sword> ().IsAttacking) {
				Hurt ();
				Debug.Log ("Sword");
			}
		}
		if (otherCollision.GetComponent<FireBall> () != null){
			Hurt();
			Debug.Log ("FireBall");
			GameObject explodeObject = Instantiate (explosionPrefab);
			explodeObject.transform.position = transform.position;	
			Destroy (otherCollision.gameObject);
		}
	}
	
}
