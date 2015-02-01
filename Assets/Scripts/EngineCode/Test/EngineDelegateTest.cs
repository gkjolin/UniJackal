using UnityEngine;
using System.Collections;

public class EngineDelegateTest : MonoBehaviour {
	public string unitName;
	public Vector3 unitPosition;
	public void Create()
	{
		EngineDelegate.instance.CreateUnit (unitName, unitPosition, Quaternion.identity);
	}

	void OnGUI()
	{
		unitName = GUILayout.TextField (unitName);
		if (GUILayout.Button ("Create")) 
		{
			Create ();
		}
	}
}
