using UnityEngine;
using System.Collections;

public class ProjectileLife : MonoBehaviour {
	ProjectileMotor motor;

	void Awake()
	{
		motor = GetComponent<ProjectileMotor>();
	}

	public virtual void OnUpdate(float dt)
	{

	}

	public virtual bool ShouldDie()
	{
		if (motor == null)
			return true;
		return motor.reachTarget;
	}
}
