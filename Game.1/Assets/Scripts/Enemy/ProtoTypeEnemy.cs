using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeEnemy : MonoBehaviour 
{
	public float whaiting;
	public float movementSpeed;
	private GameObject Target;
	private Vector3 ToLookAt;
	public float speed = 0f;
	private bool inZone;
	private Animator animator;
	bool rushing,stopwalking;

	public Vector3 RaycastHeight;
	void Start () 
	{
		stopwalking = false;
		rushing = false;
		speed = 0f;
		animator = GetComponent<Animator>();
		Target = GameObject.Find("Robo-Mainchar");
		ToLookAt = new Vector3(Target.transform.position.x,this.transform.position.y,Target.transform.position.z);
		this.transform.LookAt(ToLookAt);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//walking
	     if(!stopwalking)
		 {
			GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Target.transform.position;
		 }
			
		
		 

		//Raycast
		RaycastHeight = new Vector3(transform.position.x,transform.position.y - 0.15f, transform.position.z);
		RaycastHit hit;
		
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
		Debug.DrawRay(RaycastHeight,forward,Color.green);

		if(Physics.Raycast(transform.position,(forward), out hit))
		{
			print("Boom");

			
			if(hit.collider.gameObject.tag == "Player" && !stopwalking && hit.distance <= 2.0f)
			{
			StartCoroutine(Rush());
			}
		}

		if(rushing)
		{
		transform.position += transform.forward * Time.deltaTime * movementSpeed;
		}
		
		

	}

	void FixedUpdate()
	{
		//For Looking
	Vector3 direction = Target.transform.position - transform.position;
	Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
 	transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
	}

	private IEnumerator Rush()
    {
		print("go");
		//animator.Play("Rush");
		stopwalking = true;
		GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
		yield return new WaitForSeconds(whaiting);
		rushing = true;
		yield return new WaitForSeconds(1);
		rushing =false;
		stopwalking = false;
		GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;

		

	}

	
}
