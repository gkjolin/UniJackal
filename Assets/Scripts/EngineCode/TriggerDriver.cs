using UnityEngine;
using System.Collections;

public class TriggerDriver : MonoBehaviour {
	public TriggerListener[] enterListeners;
	public TriggerListener[] stayListeners;
	public TriggerListener[] exitListeners;

	void OnTriggerEnter(Collider other)
	{
		DoListeners(enterListeners, other);
	}
	
	void OnTriggerStay(Collider other)
	{
		DoListeners(stayListeners, other);
	}
	
	void OnTriggerExit(Collider other)
	{
		DoListeners(exitListeners, other);
	}
	
	void DoListeners(TriggerListener[] listeners, Collider other)
	{
		if (listeners != null)
		{
			foreach (TriggerListener l in listeners)
				l.DoAction(gameObject, other);
		}
	}
}
