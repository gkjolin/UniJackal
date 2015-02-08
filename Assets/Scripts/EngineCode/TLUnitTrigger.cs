using UnityEngine;
using System.Collections;

public class TLUnitTrigger : TriggerListener {
	Unit unit;

	void Awake()
	{
		unit = GetComponent<Unit>();
	}

	public override void DoAction (GameObject self, Collider other)
	{
		if (unit != null)
		{
			EngineDelegate.instance.UnitTriggered(unit, other);
		}
	}
}
