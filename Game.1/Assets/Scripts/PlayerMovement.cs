using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour{

	public float moveSpeed;
	private Rigidbody myRigidbody;
	private Animator anim;
	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private int Vertical;
	private int Horizontal;
	private Vector3 currVel,curPos,position,lastPos;

	// Use this for initialization
	void Start () {
		Vertical = 0;
		Horizontal = 0;
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody> ();
		//StartCoroutine( CalcVelocity() );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(this.gameObject.layer == 8)
		{
			foreach(Transform t in transform)
			{
				t.gameObject.layer = 8;
			}
		}
		if(this.gameObject.layer == 0)
		{
			foreach(Transform t in transform)
			{
				t.gameObject.layer = 0;
			}
		}

	 	curPos = this.transform.position;
    	 if(curPos == lastPos) 
	 	{
        	anim.SetBool("Moving",false);
     	}else
		{
		  anim.SetBool("Moving",true);
	 }
     lastPos = curPos;



	
	moveInput = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0.0f,CrossPlatformInputManager.GetAxis("Vertical"));
	moveVelocity = moveInput * moveSpeed;
	float lockPos = 0f;
	
	}
	
	void FixedUpdate()
	{
		if(this.gameObject.layer != 8)
		{
		myRigidbody.velocity = moveVelocity;
		if(moveVelocity != Vector3.zero)
		this.transform.rotation = Quaternion.LookRotation(moveVelocity);
		}
	}

	
}

	/*moveInput = new Vector3 (Vertical,0f, Horizontal);
		moveVelocity = moveInput * moveSpeed;
		print(Vertical);
	
	
	if(Input.GetKey("a")){
		Vertical = -1;
	}else if(Input.GetKey("d")){
		Vertical = 1;
	} else{
		Vertical = 0;
	}

	if(Input.GetKey("s")){
		Horizontal = -1;
	}else if(Input.GetKey("w")){
		Horizontal = 1;
	} else{
		Horizontal = 0;
	}
*/

