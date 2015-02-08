using UnityEngine;
using System.Collections;

public class TLProjectileTrigger : TriggerListener {
	Projectile proj;
	void Awake()
	{
		proj = GetComponent<Projectile>();
	}
	
	public override void DoAction (GameObject self, Collider other)
	{
		if (proj != null)
		{
			EngineDelegate.instance.ProjectileTriggered(proj, other);
		}
	}
}
