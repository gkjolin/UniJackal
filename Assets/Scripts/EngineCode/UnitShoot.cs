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
				EngineDelegate.instance.CreateProjectile("Rocket_Red", transform.position, transform.rotation);
				timeCnt = shootCoolDown;
			}
		}
		
		if (Input.GetKeyDown (KeyCode.K))
		{
			EngineDelegate.instance.CreateProjectile("Bullet", transform.position, Quaternion.identity);
		}
	}
}
