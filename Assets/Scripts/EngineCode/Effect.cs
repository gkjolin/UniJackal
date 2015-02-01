using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {
	public float lifeTime = 1.0f;
	float timeCnt = 0.0f;
	// Use this for initialization
	void Start () {
		timeCnt = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeCnt -= Time.deltaTime;
		if (timeCnt <= 0.0f)
			Destroy (this.gameObject);
	}
}
