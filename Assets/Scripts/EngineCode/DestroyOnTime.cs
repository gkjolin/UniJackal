using UnityEngine;
using System.Collections;

public class DestroyOnTime : MonoBehaviour {
	public float time;
	float timeCnt;
	// Use this for initialization
	void Start()
	{
		timeCnt = time;
	}
	
	// Update is called once per frame
	void Update () {
		timeCnt -= Time.deltaTime;
		if (timeCnt <= 0.0f)
			Destroy(this.gameObject);
	}
}
