using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpawn : MonoBehaviour {
	public Transform Spawn;
	// Use this for initialization
	void Start () {
			//Spawn = GetComponentInChildren<Transform>(); 
			Spawn =  GameObject.Find("SpawnPoint").transform;
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
		other.transform.position = Spawn.transform.position;
		other.gameObject.layer = 0;
		}
	
		
		
	}
	
}
