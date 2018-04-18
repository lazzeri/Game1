using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject Enemy;
	public Transform[] SpawnPoints;
	public GameObject[] Enemies;
	
	// Use this for initialization
	void Start () 
	{
		SpawnPoints = new Transform[4];

		for(int i = 0; i < 4; i++)
		{
			SpawnPoints[i] = this.gameObject.transform.GetChild(i);
		}

		Enemies = new GameObject[4]; 	
		
		for(int i = 0; i < 4; i++)
		{
		Enemies[i] = ((GameObject)Instantiate(Enemy));
		Enemies[i].transform.position = SpawnPoints[i].transform.position;
		Enemies[i].SetActive(false);
		} 
		
		StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator SpawnEnemies()
	{
		 
		for(int i = 0; i < 4; i++)
		{
		Enemies[i].SetActive(true);
		yield return new WaitForSeconds(1);
		} 

		
		
	}
}
