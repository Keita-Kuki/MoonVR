using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EhanMove : MonoBehaviour {
	public float speed = 3f;
	public float jumppower = 200f;
	public float directionConstant = 1.25f;

	public bool isstarted;
	public bool isgoaled;

	private Vector3 velocity;
	
	Rigidbody rb;
 
	void Start(){
		rb = GetComponent<Rigidbody> ();
		velocity = new Vector3(0,0,0);
		isstarted = false;
		isgoaled = false;
	}
 
	void Update () {
		velocity.x = Input.GetAxis ("Vertical") * speed / Time.deltaTime;
		velocity.z = -directionConstant * velocity.x;
	}
 
	void FixedUpdate(){
		rb.velocity = velocity;
		if(Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector3.up * jumppower * 100000);
		}


	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "StartLine"){
			isstarted = true;
		}
		if (other.gameObject.tag == "GoalLine"){
			isgoaled = true;
		}
    }

}
