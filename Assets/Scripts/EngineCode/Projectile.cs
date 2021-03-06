﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public ProjectileMotor motor;
	public ProjectileLife[] lifes;
	public ProjectileOnDie[] onDies;

	bool dead = false;
	// Use this for initialization
	void Awake()
	{
		dead = false;
		motor = GetComponent<ProjectileMotor> ();
		lifes = GetComponents<ProjectileLife> ();
		onDies = GetComponents<ProjectileOnDie> ();
		OnAwake ();
	}

	protected virtual void OnAwake()
	{

	}
	
	public void Die()
	{
		dead = true;
	}
	// Update is called once per frame
	void Update () {
		if (motor != null)
			motor.OnUpdate (Time.deltaTime);
		if (dead) 
		{
			OnDie();
			Destroy (this.gameObject);
			return;
		}
		if (lifes != null) 
		{
			foreach (ProjectileLife life in lifes) 
			{
				life.OnUpdate(Time.deltaTime);
				if (life.ShouldDie())
				{
					dead = true;
					break;
				}
			}
		}
		OnUpdate (Time.deltaTime);
	}

	protected virtual void OnUpdate(float dt)
	{

	}

	protected virtual void OnDie()
	{
		if (onDies != null) 
		{
			foreach (ProjectileOnDie onDie in onDies)
			{
				onDie.DieAction();
			}
		}
	}
}
