using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

public float speed = 3.5f;
public float runMod = 5f;
public float jumpingForce = 5f;
public float rotateSpeed = 40f;
private bool canJump = false;
private bool isHit = false;
	public bool isTeleported = false;
private float hitTimer;
public Magic magic;
public int health = 5;
public float knockBackSpeed = 50f;
	private float knockBackTimer;
public Sword sword;
	public Animator playerAnimator;

	public GameObject model;

  public float mouseSensitivity = 80.0f;
     public float clampAngle = 80.0f;
 
     private float rotY = 0.0f; // rotation around the up/y axis
     private float rotX = 0.0f; // rotation around the right/x axis

	// Use this for initialization
	void Start () {
		  Vector3 rot = transform.localRotation.eulerAngles;
         rotY = rot.y;
         rotX = rot.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (knockBackTimer > 0) {
			knockBackTimer -= Time.deltaTime;

		} else {
			float mouseX = Input.GetAxis("Mouse X");
			float mouseY = -Input.GetAxis("Mouse Y");
 
			 rotY += mouseX * mouseSensitivity * Time.deltaTime;
			 rotX += mouseY * mouseSensitivity * Time.deltaTime;
	 
			 rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
	 
			 Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
			 transform.rotation = localRotation;
			
			
			if (Input.GetMouseButtonDown(0)){
				speed *= runMod;
			}
			if (Input.GetMouseButtonUp(0)){
				speed = speed / runMod;
			}
			if (Input.GetMouseButtonDown(1) && canJump){
				canJump = false;
				GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
			}

			playerAnimator.SetBool ("OnGround", canJump);
			isHit = false;	
			isTeleported = false;

			if (Input.GetKeyDown("z")){
				sword.Attack();
			}
			if (Input.GetKeyDown("space") && canJump){
				canJump = false;
				GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
			}		
			if (Input.GetKey("left")){
				transform.RotateAround(transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
			} 
			if (Input.GetKey("right")){
				transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
			} 
			if (Input.GetKey ("up")) {
				transform.position += transform.forward * speed * Time.deltaTime;
			} 
			if (Input.GetKey("down")){
				transform.position -= transform.forward * speed * Time.deltaTime;
			} 
			if (Input.GetKeyDown("x")){
				magic.Attack();
			}
		} 
	}

	void OnCollisionEnter (Collision collision){
		if (collision.transform.name == "Plane"){
			//Debug.Log ("Let the bodies!");
			canJump = true;
		}

		if (collision.gameObject.GetComponent<Enemy> () != null){
			Hit ((transform.position = collision.transform.position).normalized);
		  }
	}
	 
	void OnTriggerEnter (Collider otherCollider){
		if (otherCollider.GetComponent<EnemyBullet> () != null){
			Hit ((transform.position = otherCollider.transform.position).normalized);
		}
	}

	private void Hit (Vector3 direction) {
		if (isHit){
		}else{
			Vector3 knockbackDirection = (direction + Vector3.up).normalized;
			GetComponent<Rigidbody> ().AddForce (knockbackDirection * knockBackSpeed);
			knockBackTimer = 1f;
			isHit = true;
		
			health--;
			if (health <= 0) {
				Destroy (model);
				SceneManager.LoadScene ("GameOver");
			}
			
		}
	}

	public void setTeleported (bool setTo){
		isTeleported = setTo;

	}

}
