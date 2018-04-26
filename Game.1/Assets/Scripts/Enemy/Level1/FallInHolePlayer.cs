using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHolePlayer : MonoBehaviour {
	 public Transform position1, position2;
   	 bool bDrag1, bDrag2;
     public float moveSpeed = 10.0f;
	

	// Use this for initialization
	void Start () {
		bDrag1 = false;
        bDrag2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		  	
			   if (bDrag1 || bDrag2)
        {

            if (transform.position != position1.position && bDrag1 == true)
            {
                print("Trying");
                transform.position = Vector3.MoveTowards(transform.position, position1.position, moveSpeed * Time.deltaTime);
               
            }
            if (transform.position == position1.position)
            {
                print("True");
                bDrag1 = false;
                bDrag2 = true;
            }
            if (bDrag2 == true)
            {
                print("xd");
                transform.position = Vector3.MoveTowards(transform.position, position2.position, moveSpeed * Time.deltaTime);
            }
            if(transform.position == position2.position)
            {
                bDrag2 = false;

            }


        }
	}
	
	 void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
          
            print("trying");
			GetComponent<PlayerMovement>().enabled = false;
          //	this.gameObject.GetComponent<PlayerMovement>().enabled = false;
		  	GetComponent<Rigidbody>().isKinematic = true;

            position1 = other.gameObject.transform.GetChild(0).transform;
            position2 = other.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
           
            bDrag1 = true;

			//kinematic machen und playermovement ausschalten

        }
    }
}
