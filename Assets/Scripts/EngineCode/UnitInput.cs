using UnityEngine;
using System.Collections;

public class UnitInput : MonoBehaviour {
	public UnitMotor motor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (motor != null) 
		{
			Vector3 deltaPos = Vector3.zero;
			if (Input.GetKey(KeyCode.W))
				deltaPos += Vector3.forward;
			if (Input.GetKey(KeyCode.S))
				deltaPos += Vector3.back;
			if (Input.GetKey(KeyCode.A))
				deltaPos += Vector3.left;
			if (Input.GetKey(KeyCode.D))
				deltaPos += Vector3.right;
			deltaPos *= 10.0f;
			motor.target = motor.transform.position + deltaPos;
		}
	}
}
