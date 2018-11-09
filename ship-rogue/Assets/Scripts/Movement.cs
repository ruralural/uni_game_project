using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Controller {
	
	// object stats
	public float maxSpeed = 666666f;
	public float timeZeroToMax = 2.5f;
	public float timeMaxToZero = 6f;
	public float timeBrakeToZero = 1f;
	public float turnAnglePerSec = 90f;
	//stats calculated at runtime
	float accelRatePerSec;
	float decelRatePerSec;
	float brakeRatePerSec;
	// current object state
	float forwardVelocity; // tell if it should move forward	
	float currentTurn;	// tell whether it should rotate
	bool accelChange;

	void Start(){
			accelRatePerSec = maxSpeed / timeZeroToMax;
			decelRatePerSec = -maxSpeed / timeMaxToZero;
			brakeRatePerSec = -maxSpeed / timeBrakeToZero;
			forwardVelocity = 0f;
			currentTurn = 0f;
	}

	public override void ReadInput(InputData data){
//			register and execute object controls
//			current turn is additionally multiplied by a conditional check bc
//			it's a positive turn and there's also a negative turn to the left
//			(data.axis[1] > 1 ? 1 : -1) if it's greater than zero -> 1 otherwise -1
			if(data.axes[1] != 0){
				currentTurn = turnAnglePerSec * Time.deltaTime * (data.axes[1] > 0 ? 1 : -1);
			}
//			if (Input.GetKey("w")){
			if(data.buttons[0] ==  true) {
				Debug.Log("LETSSGO");
		
				forwardVelocity += accelRatePerSec * Time.deltaTime;
				forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
//				rb.AddForce(0, 0, forwardVelocity* Time.deltaTime);
				accelChange = true;
			
			}
			if(data.buttons[1] ==  true) {
				forwardVelocity += brakeRatePerSec * Time.deltaTime;
				forwardVelocity = Mathf.Max(forwardVelocity, 0);
				accelChange = true;
			}	
			newInput = true;
	}
	
	// Update is called once per frame
	// TODO: refactor by creating a method for Acceleration
	void LateUpdate () {
			// if moving forward, turn object
			//check if whether it's moving bc it's not a tank ;)
			if(forwardVelocity > 0f) {
				//taking our current rotation + currentTurn on the y-axis and converting to a quatern 
				rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0, currentTurn, 0));
			}	
			//if no acceleration input, decelerate 
			if(!newInput || !accelChange){
				forwardVelocity += decelRatePerSec * Time.deltaTime;
				forwardVelocity = Mathf.Max (forwardVelocity, 0);
				accelChange = true;
			}
			//move object based on current  velocity
			rb.velocity = transform.forward * forwardVelocity;

		//	if(newInput){
		//		rb.velocity = transform.forward * forwardVelocity;
		//	} else {
		//		forwardVelocity += decelRatePerSec * Time.deltaTime;
		//		forwardVelocity = Mathf.Max (forwardVelocity, 0);
		//		rb.velocity = transform.forward * forwardVelocity;
		//	}

		//	reset for the next frame
			accelChange = false;
			newInput = false;
			currentTurn = 0f;
	}
	
}
