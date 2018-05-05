using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {


	public GameObject[] Enemies;
	public ProtoTypeEnemy scProto;
	public FallInHolEnemy scFallinHole;
	public RusherDamage scRusherDamage;
	
	// Use this for initialization
	void Start () 
	{
		Enemies = new GameObject[4]; 	
		Enemies[0] = GameObject.Find("Rusher 1");
		Enemies[1] = GameObject.Find("Rusher 2");
		Enemies[2] = GameObject.Find("Rusher 3");
		Enemies[3] = GameObject.Find("Rusher 4");
		
		
		StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator SpawnEnemies()
	{
		 
		for(int i = 0; i < 4; i++)
		{
			scProto = Enemies[i].GetComponent<ProtoTypeEnemy>();
			scFallinHole = Enemies[i].GetComponent<FallInHolEnemy>();
			scRusherDamage = Enemies[i].GetComponent<RusherDamage>();

			scProto.enabled = true;
			scFallinHole.enabled = true;
			scRusherDamage.enabled = true;
		
		yield return new WaitForSeconds(2);
		} 

		
		
	}
}
