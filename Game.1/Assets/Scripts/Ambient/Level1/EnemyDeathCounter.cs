using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCounter : MonoBehaviour {

	public static int counter = 3;
	public Animator ACDoor;
	public GameObject Door;
    public GameObject WallMidle;
    public GameObject Light1, Light2,Light1Red,Light2Red;
    Behaviour halo1,halo1r,halo2,halo2r;

    // Use this for initialization
    void Start () {
        Light1 = GameObject.Find("RoomCollider and NavMesh/Light/SphereGreen");
        Light2 = GameObject.Find("RoomCollider and NavMesh/Light 2/SphereGreen");

        Light1Red = GameObject.Find("RoomCollider and NavMesh/Light/SphereRed");
        Light2Red = GameObject.Find("RoomCollider and NavMesh/Light 2/SphereRed");


        halo1 = (Behaviour)Light1.GetComponent("Halo");
        halo1r = (Behaviour)Light1Red.GetComponent("Halo");
        halo2 = (Behaviour)Light2.GetComponent("Halo");
        halo2r = (Behaviour)Light2Red.GetComponent("Halo");


        halo1.enabled = false;
        halo2.enabled = false;


        WallMidle = GameObject.Find("RoomCollider and NavMesh/Back Wall Middle");
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
            halo1.enabled = true;
            halo2.enabled = true;
            halo1r.enabled = false;
            halo2r.enabled = false;
            
            ACDoor.Play("Open");
            WallMidle.SetActive(false);
		}
	}

	
}
