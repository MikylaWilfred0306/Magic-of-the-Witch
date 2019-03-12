using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {

public GameObject bulletPrefab;

	public void Attack (){
		GameObject bulletObject = Instantiate (bulletPrefab);
		bulletObject.transform.position = transform.position + transform.forward;
		FireBall bullet = bulletObject.GetComponent<FireBall>();
			
		//bullet.shootingDirection = transform.position;
		bullet.shootingDirection = transform.forward;
			//bullet.shootingDirection = new Vector3(Random.Range(-.15f, .15f), Random.Range(-.15f, .15f), 1);
		
	}
}
