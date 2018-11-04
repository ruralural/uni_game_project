using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyaboardTracker : DeviceTracker{
	
	public KeyCode[] buttonKeys;
	public AxisButtons[] axisKeys;
	
	void Reset() {
		im = GetComponent<InputManager>();
		buttonKeys = new KeyCode[im.buttonCount];
		axisKeys = new AxisButtons[im.axisCount];
	}
	// Update is called once per frame
	void Update () {
		//check for inputs, if inputs detected, set newData to true
		//populate InputData to pass to the InputManager
		for (int i = 0; i < axisKeys.Length; i++) {
			float val = 0f;
			if (Input.GetKey(axisKeys[i].positive)) {
				val += 1;
				newData = true;
			}
			if (Input.GetKey(axisKeys[i].negative)) {
				val -= 1;
				newData = true;
			}
			data.axes[i] = val;
		}
		for (int i = 0; i < buttonKeys.Length; i++) {
			if (Input.GetKey(buttonKeys[i])) {
				data.buttons [i] = true;
				newData = true;
			}
		}
		if (newData){
			im.PassInput(data);
			newData = false;
			data.Reset();
		}	
	}
}
[System.Serializable]
public struct AxisButtons {
	public KeyCode positive;
	public KeyCode negative;
}
