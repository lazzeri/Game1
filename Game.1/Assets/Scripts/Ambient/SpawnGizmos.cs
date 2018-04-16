using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGizmos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position,new Vector3(0.1f,0.1f,0.1f));
	}
}
