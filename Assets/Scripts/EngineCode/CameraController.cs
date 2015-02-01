using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject targetObject;
	public Vector3 offset = new Vector3(0.0f, 10.0f, 0.0f);
	public float ratio = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetObject != null)
		{
			transform.position = targetObject.transform.position + offset;
		}
	}
}
