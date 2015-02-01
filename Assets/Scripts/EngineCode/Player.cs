using UnityEngine;
using System.Collections;

public class Player : Unit {
	protected override void OnAwake ()
	{
		UnitInput input = GetComponent<UnitInput> ();
		if (input == null)
			input = gameObject.AddComponent<UnitInput> ();
		input.motor = GetComponent<UnitMotor> ();
		CameraController cc = Camera.main.GetComponent<CameraController> ();
		if (cc != null)
			cc.targetObject = this.gameObject;
	}
}
