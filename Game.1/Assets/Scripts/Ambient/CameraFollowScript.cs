using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	public float entfernung = 5.0f;
	public float entfernung2 = 5.0f;
	 GameObject GameChar;
	void Start () {
		GameChar = GameObject.Find("Robo-Mainchar");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(transform.position.x,GameChar.transform.position.y + entfernung, GameChar.transform.position.z + entfernung2);
	}
}
