using UnityEngine;
using System.Collections;

public class Msg_MotorArrive
{
	public UnitMotor motor;

	public override string ToString ()
	{
		return motor.gameObject.name + " : Arrived"; 
	}
}

public class UnitMotor : MonoBehaviour {
	public Vector3 target;
	public bool noYMovement;
	public float speed = 1.0f;
	public CharacterController characterController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance = target - transform.position;
		if (noYMovement) distance = new Vector3(distance.x, 0.0f, distance.z);
		Vector3 dp = distance.normalized * speed * Time.deltaTime;
		Vector3 p1 = transform.position + dp;
		Vector3 p2 = transform.position;
		Vector3 pmin = new Vector3(Mathf.Min(p1.x, p2.x), Mathf.Min(p1.y, p2.y), Mathf.Min(p1.z, p2.z));
		Vector3 pmax = new Vector3(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y), Mathf.Max(p1.z, p2.z));
		Vector3 newPos = new Vector3(Mathf.Clamp(target.x, pmin.x, pmax.x),
									 Mathf.Clamp(target.y, pmin.y, pmax.y),
									 Mathf.Clamp(target.z, pmin.z, pmax.z));
		//transform.position = newPos;
		transform.LookAt (new Vector3(newPos.x, transform.position.y, newPos.z));
		characterController.Move(newPos - transform.position);
	}
}
