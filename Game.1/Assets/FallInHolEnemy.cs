using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInHolEnemy : MonoBehaviour
{
    public Transform position1, position2;
    public ProtoTypeEnemy scProto;
    bool bDrag1, bDrag2;
    public float moveSpeed = 10.0f;
    // Use this for initialization
    void Start()
    {
        bDrag1 = false;
        bDrag2 = false;
        scProto = GetComponent<ProtoTypeEnemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole")
        {

            scProto.enabled = false;
            position1 = other.gameObject.transform.GetChild(0).transform;
            position2 = other.gameObject.transform.GetChild(0).transform.GetChild(0).transform;
            other.gameObject.SetActive(false);
           // gameObject.layer = 8;
            bDrag1 = true;

        }
    }

    void Update()
    {
        if (bDrag1)
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
                print("xd");
                transform.position = Vector3.MoveTowards(transform.position, position2.position, moveSpeed * Time.deltaTime);
            }


        }

    }
}

    

