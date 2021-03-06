﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHolEnemy : MonoBehaviour
{
    public Transform position1, position2;
    public ProtoTypeEnemy scProto;
    bool bDrag1, bDrag2;
    public float moveSpeed = 10.0f;
    public bool inhole = false;
    
    // Use this for initialization
    void Start()
    {
        bDrag1 = false;
        bDrag2 = false;
        scProto = GetComponent<ProtoTypeEnemy>();
    }

    public bool getinhole()
    {
        return inhole;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {
            Destroy(this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>());
            this.gameObject.GetComponent<RusherInHoleOverview>().setbool(true);
            scProto.enabled = false;    
            GetComponent<ProtoTypeEnemy>().enabled = false;
            GetComponent<RusherDamage>().enabled = false;
            GetComponent<RusherHitsObject>().enabled = false;
            Destroy(this.gameObject.GetComponent<CapsuleCollider>());
            Destroy(this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>());
            Destroy(this.gameObject.GetComponent<RusherDamage>());
            Destroy(this.gameObject.GetComponent<ProtoTypeEnemy>());

            this.GetComponent<Rigidbody>().isKinematic = true;
            position1 = other.gameObject.transform.GetChild(0).transform;
            position2 = other.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
            other.gameObject.SetActive(false);
            
            bDrag1 = true;

        }
    }

    void Update()
    {
      
        if (bDrag1 || bDrag2)
        {

            if (transform.position != position1.position && bDrag1 == true)
            {
                
               transform.position = Vector3.MoveTowards(transform.position, position1.position, moveSpeed * Time.deltaTime);
               
            }
            if (transform.position == position1.position)
            {
                bDrag1 = false;
                bDrag2 = true;
            }
            if (bDrag2 == true)
            {
         
                transform.position = Vector3.MoveTowards(transform.position, position2.position, moveSpeed * Time.deltaTime);
            }
            if(transform.position == position2.position)
            {
               //Destroy(this.gameObject.GetComponent<Rigidbody>());
               

                EnemyDeathCounter.counter = EnemyDeathCounter.counter + 1;
                print(EnemyDeathCounter.counter);

                bDrag2 = false;

            }


        }

    }
}

    

