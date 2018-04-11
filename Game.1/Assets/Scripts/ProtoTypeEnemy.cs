using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeEnemy : MonoBehaviour {

	private GameObject Target;
	
	void Start () {
		Target = GameObject.Find("Robo-Mainchar");
	}
	
	// Update is called once per frame
	void Update () {
	     GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Target.transform.position;

	}
}
