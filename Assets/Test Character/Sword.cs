using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float swingingSpeed = 100f;
	public float cooldwonSpeed = 2;
	public float cooldwonDuration = 0.2f;
	public float attackDuration = 0.1f;
	private Quaternion targetRotation;
	private float cooldownTimer;
	private bool isAttacking;
	public bool IsAttacking {
		get { return isAttacking; }
	}
	// Use this for initialization
	void Start () {
		targetRotation = Quaternion.Euler (0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking) {
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, Time.deltaTime * swingingSpeed);
		} else {
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, Time.deltaTime * cooldwonSpeed);
		}

		cooldownTimer -= Time.deltaTime;
	}
	
	public void Attack(){
		if (cooldownTimer > 0f) {
			return;
		}
		targetRotation = Quaternion.Euler (-90, 0, 0);
		cooldownTimer = cooldwonDuration;
		StartCoroutine (CooldownWait ());
	}

	private IEnumerator CooldownWait(){
		isAttacking = true;
		yield return new WaitForSeconds (attackDuration);
		isAttacking = false;
		targetRotation = Quaternion.Euler (0,0,0);
	}
}