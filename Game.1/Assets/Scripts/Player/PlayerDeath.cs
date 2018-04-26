using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public static GameObject[]  Children;
    public Transform[] positions;
    public static GameObject Char;
    public static PlayerMovement Movement;
	// Use this for initialization
	void Start ()
    {
        Movement = this.gameObject.GetComponent<PlayerMovement>();
        Char = this.gameObject;

        positions = new Transform[7];
        Children = new GameObject[7];
      for(int i = 0; i < 7; i++)
        {
            Children[i] = transform.GetChild(i).gameObject;
        }
       
       

    }
	
	
public static void Die()
    {
        Movement.enabled = false;
        Char.gameObject.GetComponent<Animator>().enabled = false;
        for (int i = 0; i < 7; i++)
        {
            Rigidbody gameObjectsRigidBody = Children[i].AddComponent<Rigidbody>();
            Char.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
