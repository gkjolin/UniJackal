using UnityEngine;
using System.Collections;

public class EngineDelegate : MonoBehaviour {
	public static EngineDelegate instance{ get; private set; }
	const string UNIT_PATH = "Prefabs/Unit/";
	const string PROJECTILE_PATH = "Prefabs/Projectile/";
	const string EFFECT_PATH = "Prefabs/Effect/";

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
		instance = this;

	}

	public GameObject CreateUnit(string name)
	{
		return CreateUnit (name, Vector3.zero, Quaternion.identity);
	}

	public GameObject CreateUnit(string name, Vector3 position, Quaternion rotation)
	{
		string loadPath = UNIT_PATH + name;
		GameObject pref = Resources.Load<GameObject> (loadPath);
		if (pref == null) 
		{
			Debug.Log (this.GetType().ToString() + " : " + name + " unit prefab not found");
			return null;
		}
		GameObject inst = (GameObject)GameObject.Instantiate (pref, position, rotation);
		UnitMotor motor = inst.GetComponent<UnitMotor> ();
		if (motor != null)
			motor.target = inst.transform.position;
		return inst;
	}

	public GameObject CreateProjectile(string name, Vector3 position, Quaternion rotation)
	{
		string loadPath = PROJECTILE_PATH + name;
		GameObject pref = Resources.Load<GameObject> (loadPath);
		if (pref == null) 
		{
			Debug.Log (this.GetType ().ToString () + " : " + name + " projectile prefab not found");
			return null;
		}
		GameObject inst = (GameObject)GameObject.Instantiate (pref, position, rotation);
		return inst;
	}

	public GameObject CreateEffect(string name, Vector3 position, Quaternion rotation)
	{
		string loadPath = EFFECT_PATH + name;
		GameObject pref = Resources.Load<GameObject> (loadPath);
		if (pref == null) 
		{
			Debug.Log (this.GetType ().ToString () + " : " + name + " effect prefab not found");
			return null;
		}
		GameObject inst = (GameObject)GameObject.Instantiate (pref, position, rotation);
		return inst;
	}

	public void Send(object msg)
	{
		if (msg is Msg_MotorArrive)
		{
			Debug.Log (msg.ToString());
		}
	}
}
