using UnityEngine;
using System.Collections;

public class ProjectileOnDie : MonoBehaviour {
	public string effectName;

	public virtual void DieAction()
	{
		EngineDelegate.instance.CreateEffect (effectName, transform.position, Quaternion.identity);
	}
}
