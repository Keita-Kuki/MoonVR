using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EhanMove : MonoBehaviour {

	public bool minus10s;
	public bool isstarted;
	public bool isgoaled;

 
	void Start(){
		isstarted = false;
		isgoaled = false;
		minus10s = false;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "StartLine"){
			isstarted = true;
		}
		if (other.gameObject.tag == "GoalLine"){
			isgoaled = true;
		}
    }


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Point"){
			minus10s = true;
			Destroy(other.gameObject);
		}
	}

	public void Afterminus10s(){
		minus10s = false;
	}

}
