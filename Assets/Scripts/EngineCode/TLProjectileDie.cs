using UnityEngine;
using System.Collections;

public class TLProjectileDie : TriggerListener {
	public override void DoAction (GameObject self, Collider other)
	{
		Projectile p = self.GetComponent<Projectile>();
		if (p != null) p.Die();
	}
}
