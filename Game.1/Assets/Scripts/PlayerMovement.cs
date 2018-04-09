using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private int Vertical;
	private int Horizontal;

	// Use this for initialization
	void Start () {
		Vertical = 0;
		Horizontal = 0;
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3 (Vertical,0f, Horizontal);
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

	}

	void FixedUpdate(){
		myRigidbody.velocity = moveVelocity;
		
		
	}


}
