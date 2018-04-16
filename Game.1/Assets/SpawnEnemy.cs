using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject Enemy;
	
	// Use this for initialization
	void Start () {

	GameObject[] Enemies = new GameObject[4]; 	
	
		for(int i = 0; i < 4; i++)
	{
		Enemies[i] = ((GameObject)Instantiate(Enemy));
	}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator SpawnEnemies()
	{
		
		yield return new WaitForSeconds(0.15f);
	}
}
