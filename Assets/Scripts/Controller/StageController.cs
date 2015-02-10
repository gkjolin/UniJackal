using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitItem
{
	public int id;
	public Unit unit;
}

public class StageController : GameController {
	Dictionary<int, Unit> dictUnits = new Dictionary<int, Unit>();
	
	public void CreateUnit(int id, string name)
	{
		CreateUnit(id, name, Vector3.zero);
	}
	
	public void CreateUnit(int id, string name, Vector3 pos)
	{
		if (dictUnits.ContainsKey(id))
			return;
	
		GameObject go = EngineDelegate.instance.CreateUnit(name, pos, Quaternion.identity);
		if (go != null)
		{
			Unit unit = go.GetComponent<Unit>();
			if (unit == null)
			{
				GameObject.Destroy(go);
				return;
			}
			dictUnits[id] = unit;
			unit.unitId = id;
		}
	}
	
	public void KillUnit(int id)
	{
		if (!dictUnits.ContainsKey(id))
			return;
		
		Unit unit = dictUnits[id];
		unit.Die();
		dictUnits.Remove(id);
	}
	
	public UnitItem[] GetItems()
	{
		UnitItem[] ret = new UnitItem[dictUnits.Count];
		/*
		for (int i = 0, n = dictUnits.Count; i < n; i++)
		{
			int theId = dictUnits.Keys;
			Unit uni = dictUnits[theId];
			ret[i] = new UnitItem();
			ret[i].id = theId;
			ret[i].unit = uni;
		}
		*/
		int i = 0;
		foreach (int id in dictUnits.Keys)
		{
			Unit uni = dictUnits[id];
			ret[i] = new UnitItem();
			ret[i].id = id;
			ret[i].unit = uni;
			i++;
		}
		
		return ret;
	}

	public override void Receive (ControllerMessage msg)
	{
		if (msg is Msg_UnitHit)
		{
			Msg_UnitHit unitHit = msg as Msg_UnitHit;
			Debug.Log (unitHit.unit.gameObject.ToString());
			KillUnit(unitHit.unit.unitId);
		}
	}
}
