using UnityEngine;
using System.Collections;

public class ProjectileMotor : MonoBehaviour {
	public float distance;
	public float speed;
	Vector3 target;
	public bool reachTarget{ get; private set;}
	// Use this for initialization
	void Start () {
		target = transform.position + transform.forward * distance;
	}
	
	// Update is called once per frame
	public void OnUpdate (float dt) {
		Vector3 distance = target - transform.position;
		if (distance == Vector3.zero) 
		{
			reachTarget = true;
			return;
		}
		reachTarget = false;
		Vector3 dp = distance.normalized * speed * dt;
		Vector3 p1 = transform.position + dp;
		Vector3 p2 = transform.position;
		Vector3 pmin = new Vector3(Mathf.Min(p1.x, p2.x), Mathf.Min(p1.y, p2.y), Mathf.Min(p1.z, p2.z));
		Vector3 pmax = new Vector3(Mathf.Max(p1.x, p2.x), Mathf.Max(p1.y, p2.y), Mathf.Max(p1.z, p2.z));
		Vector3 newPos = new Vector3(Mathf.Clamp(target.x, pmin.x, pmax.x),
		                             Mathf.Clamp(target.y, pmin.y, pmax.y),
		                             Mathf.Clamp(target.z, pmin.z, pmax.z));
		transform.position = newPos;
	}
}
