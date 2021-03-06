﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeEnemy : MonoBehaviour 
{
	public float whaiting;
	public float movementSpeed;
	private GameObject Target;
	private Vector3 ToLookAt;
	public float speed = 0f;
    float rushingtime = 1.5f;
	bool rushing,stopwalking;
	public float duration = 1;
	float smoothness = 0.02f;
    public Vector3 RaycastHeight, RaycastHeight2, RaycastHeight3;
    public bool bStuck;
    public Animator anim;


	public GameObject Eye,Legs1,Legs2;
	void Start () 
	{
        anim = this.gameObject.GetComponent<Animator>();
		Eye = this.gameObject.transform.Find("Sphere_001").gameObject;
		Legs1 = this.gameObject.transform.Find("Cylinder_004").gameObject;
		Legs2 = this.gameObject.transform.Find("Cylinder_005").gameObject;
		Target = GameObject.Find("Robo-Mainchar");
		bStuck = false;
		stopwalking = false;
		rushing = false;
		speed = 0f;
		
		ToLookAt = new Vector3(Target.transform.position.x,this.transform.position.y,Target.transform.position.z);
		this.transform.LookAt(ToLookAt);

		Eye.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
		Legs1.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
		Legs2.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);

	}
	
	// Update is called once per frame
	void Update () 
	{
		//walking
	     if(!stopwalking && GetComponent<UnityEngine.AI.NavMeshAgent>().enabled)
		 {
			GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Target.transform.position;
		 }
			
		
		 

		//Raycast
		RaycastHeight = new Vector3(transform.position.x,transform.position.y + 0.15f, transform.position.z);
        RaycastHeight2 = new Vector3(transform.position.x + 0.10f, transform.position.y + 0.15f, transform.position.z);
        RaycastHeight3 = new Vector3(transform.position.x - 0.10f, transform.position.y + 0.15f, transform.position.z);
        RaycastHit hit;
		
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
      
        Debug.DrawRay(RaycastHeight,forward,Color.green);
        Debug.DrawRay(RaycastHeight2, forward, Color.green);
        Debug.DrawRay(RaycastHeight3, forward, Color.green);

        if (Physics.Raycast(transform.position,(forward), out hit))
		{
			if(hit.collider.gameObject.tag == "Player" && !stopwalking && hit.distance <= 2.0f)
			{
			StartCoroutine(Rush());
			}
		}

		if(rushing)
		{
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		    transform.position += transform.forward * Time.deltaTime * movementSpeed;
		}
		
		

	}
    
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
          
           bStuck = true;

        }
    }

 /*   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rusher")
            bStuck = true;
    }*/


    void FixedUpdate()
	{
		//For Looking
	Vector3 direction = Target.transform.position - transform.position;
	Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
 	transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
	}

	private IEnumerator Rush()
    {
		float progress = 0;
		float increment = smoothness / duration;
 		
		Eye.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.red);
		Legs1.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.red);
		Legs2.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.red);

	
		stopwalking = true;
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		yield return new WaitForSeconds(whaiting);
		rushing = true;
        anim.Play("Rush");
		yield return new WaitForSeconds(rushingtime);
		rushing =false;
        yield return new WaitForSeconds(1.0f);
        stopwalking = false;
		if(!bStuck)
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true; 
        
        Eye.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
		Legs1.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);
		Legs2.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.green);

		

	}

	
}
