using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCounter : MonoBehaviour {

	public static int counter = 3;
	public Animator ACDoor;
	public GameObject Door;

	// Use this for initialization
	void Start () {
		Door = GameObject.Find("RoomCollider and NavMesh/Door");
		counter = 3;
		ACDoor = Door.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate()
	{
		if(counter == 4)
		{
			ACDoor.Play("Open");
		}
	}

	
}
