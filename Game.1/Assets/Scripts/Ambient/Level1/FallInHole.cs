using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHole : MonoBehaviour {

	public Transform myPosition;
	public Vector3 myTransform;
	float strength = 5;
	
	public Transform SecondSpawn;
	public GameObject Player;
	public float whaittime = 0.15f;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Robo-Mainchar");
		myPosition = gameObject.transform.GetChild(0).transform;//Glabi brauchi net
		SecondSpawn = gameObject.transform.GetChild(0).transform.GetChild(0);
		myTransform = new Vector3(myPosition.transform.position.x,myPosition.transform.position.y,myPosition.transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Player.layer == 8)
		{
				
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Collider>().tag == "Player")
		{
			other.gameObject.layer = 8;	
			StartCoroutine("Move");
		}
	}


	 private IEnumerator Move()
    {
      		float step = strength * Time.deltaTime;
			Player.transform.position = Vector3.MoveTowards(Player.transform.position, myPosition.position, step);
			yield return new WaitForSeconds(0.15f);
			Player.transform.position = Vector3.MoveTowards(Player.transform.position, SecondSpawn.position, step);
            
          
        
    }
}
