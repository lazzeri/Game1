using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHole : MonoBehaviour {

	Transform myPosition;
	Vector3 myTransform;
	public float strength;

	public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Robo-Mainchar");
		myPosition = GetComponent<Transform>(); //Glabi brauchi net
		myTransform = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.layer == 8)
		{
			print("LOL");
			float step = strength * Time.deltaTime;
        	Player.transform.position = Vector3.MoveTowards(Player.transform.position, myTransform, step);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Collider>().tag == "Player")
		{
			other.gameObject.layer = 8;	
		}
	}
}
