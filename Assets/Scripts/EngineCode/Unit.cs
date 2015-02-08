using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public int unitId;

	void Awake()
	{
		OnAwake ();
	}

	protected virtual void OnAwake()
	{

	}

	void Update()
	{
		OnUpdate (Time.deltaTime);
	}

	protected virtual void OnUpdate(float dt)
	{

	}
	
	public void Die()
	{
		OnDie();
	}
	
	protected virtual void OnDie()
	{
		Destroy(this.gameObject);
	}
}
