using UnityEngine;
using System.Collections;

public class ProjectileOnDie : MonoBehaviour {
	public string effectName;

	public virtual void DieAction()
	{
		EngineDelegate.instance.CreateEffect ("Explode", transform.position, Quaternion.identity);
	}
}
