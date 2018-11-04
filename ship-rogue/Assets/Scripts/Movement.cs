using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Controller {
	
//	public Rigidbody rb;

	public float maxSpeed = 666666f;
	public float timeZeroToMax = 2.5f;
	public float timeMaxToZero = 6f;
	public float timeBrakeToZero = 1f;
	float accelRatePerSec;
	float decelRatePerSec;
	float brakeRatePerSec;
	float forwardVelocity;	

	void Start(){
			accelRatePerSec = maxSpeed / timeZeroToMax;
			decelRatePerSec = -maxSpeed / timeMaxToZero;
			brakeRatePerSec = -maxSpeed / timeBrakeToZero;
			forwardVelocity = 0f;
	}

	public override void ReadInput(InputData data){

//			if (Input.GetKey("w")){
			if(data.buttons[0] ==  true) {
				Debug.Log("LETSSGO");
		
				forwardVelocity += accelRatePerSec * Time.deltaTime;
				forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
//				rb.AddForce(0, 0, forwardVelocity* Time.deltaTime);
			
			}
			if(data.buttons[1] ==  true) {
				forwardVelocity += brakeRatePerSec * Time.deltaTime;
				forwardVelocity = Mathf.Max(forwardVelocity, 0);
			}	
			newInput = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
	if(newInput){
		rb.velocity = transform.forward * forwardVelocity;
	} else {
		forwardVelocity += decelRatePerSec * Time.deltaTime;
		forwardVelocity = Mathf.Max (forwardVelocity, 0);
		rb.velocity = transform.forward * forwardVelocity;
		newInput = false;
	}
	}
	
}
