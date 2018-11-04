using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Controller : MonoBehaviour {
	
	public abstract void ReadInput(InputData data);

	protected Rigidbody rb;
	protected bool newInput; //track when we stop hittin the keyboard
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}

}
