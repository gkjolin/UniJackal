using UnityEngine;
using System.Collections;

public class Enemy : Unit {
	public float diedVelocity = 5.0f;
	public float diedAngularVelocity = 1.0f;
	public float dieDisappearTime = 99.0f;

	protected override void OnAwake ()
	{
		//Test
		UnitMotor um = GetComponent<UnitMotor>();
		if (um != null)
		{
			um.target = Vector3.zero;
		}
	}

	protected override void OnDie ()
	{
		EngineDelegate.instance.CreateEffect("Explode", this.transform.position, Quaternion.identity);
		CharacterController cc = GetComponent<CharacterController>();
		if (cc != null)
		{
			Destroy(cc);
		}
		UnitMotor um = GetComponent<UnitMotor>();
		if (um != null)
		{
			Destroy(um);
		}
		BoxCollider box = this.gameObject.AddComponent<BoxCollider>();
		box.size = new Vector3(2.0f, 2.0f, 4.0f);
		box.center = new Vector3(0.0f, 2.0f, 0.0f);
		Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
		if (rb != null)
		{
			rb.useGravity = true;
			rb.velocity = new Vector3(0.0f, diedVelocity, 0.0f);
			rb.angularVelocity = new Vector3(0.0f, 0.0f, diedAngularVelocity);
		}
		
		DestroyOnTime dot = this.gameObject.AddComponent<DestroyOnTime>();
		if (dot != null)
		{
			dot.time = dieDisappearTime;
		}
		gameObject.layer = LayerMask.NameToLayer("UnhitableObject");
		
		foreach (Transform tran in transform)
		{
			if (tran.gameObject.renderer != null)
			{
				tran.gameObject.renderer.material.color = new Color(0.3f, 0.3f, 0.3f);
			}
		}
	}
}
