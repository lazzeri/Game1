using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	public GameObject GameChar;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(transform.position.x,GameChar.transform.position.y + 10.0f, GameChar.transform.position.z -6.0f);
	}
}
