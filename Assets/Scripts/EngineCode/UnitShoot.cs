using UnityEngine;
using System.Collections;

public class UnitShoot : MonoBehaviour {
	public float shootCoolDown;
	float timeCnt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (timeCnt > 0.0f)
			timeCnt -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.J)) 
		{
			if (timeCnt <= 0.0f)
			{
				EngineDelegate.instance.CreateProjectile("Rocket", transform.position, transform.rotation);
				timeCnt = shootCoolDown;
			}
		}
	}
}
