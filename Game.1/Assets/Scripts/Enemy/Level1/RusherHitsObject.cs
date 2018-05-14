using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RusherHitsObject : MonoBehaviour
{

    public bool hunting;
    bool start;
    bool pushing2 = false;
    GameObject Player;
    public GameObject OtherPlayer;
    bool pushing = false;
    public float strenght = 10f;
    public GameObject collision = null;
    private Animator anim;
    Vector3 force, force2, fixedfoce2;
    Vector3 fixedfoce;
    bool gettinghit;
    bool xd = false;
    private ProtoTypeEnemy scProto;
    private FallInHolEnemy scFallinHole;
    private RusherDamage scRusher;
    private GameObject Enemy;
    int x = -1;
    int y = -1;
    bool pushingxy = false;

    // Use this for initialization
    void Start()
    {
        collision = null;
        hunting = false;
        start = false;
        scProto = this.GetComponent<ProtoTypeEnemy>();
        scFallinHole = this.GetComponent<FallInHolEnemy>();
        scRusher = this.GetComponent<RusherDamage>();
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision c)
    {
        
        if (c.transform.tag == "Rusher" && c.gameObject.GetComponent<RusherHitsObject>().getHunting() == false && pushing2 == false)
        { 
            collision = c.gameObject;
        if (collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null && gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            {


                hunting = true;

                c.gameObject.GetComponent<RusherHitsObject>().enabled = false;
                c.gameObject.GetComponent<ProtoTypeEnemy>().enabled = false;
                c.gameObject.GetComponent<RusherDamage>().enabled = false;
                c.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                c.gameObject.GetComponent<Rigidbody>().useGravity = false;

                gameObject.GetComponent<ProtoTypeEnemy>().enabled = false;
                gameObject.GetComponent<RusherDamage>().enabled = false;
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;


                force = c.transform.position - transform.position;
                fixedfoce = new Vector3(force.x * -2, 0.0f, force.z * -2);
                fixedfoce.Normalize();

                force2 = transform.position - c.transform.position;
                fixedfoce2 = new Vector3(force2.x * -2, 0.0f, force2.z * -2);
                fixedfoce2.Normalize();


                StartCoroutine(PushAway());
            }
    }
    }

    /*  if (c.transform.tag == "WallX")
      {
          x = 1;
          y = 0;

          print("hit");
          collision = c.gameObject;

          force = transform.position - c.transform.position;
          print(force);
          fixedfoce = new Vector3(force.x * x, 0.0f, force.z * y);


          fixedfoce.Normalize();
          StartCoroutine(PushAwayXY());
      }

      if (c.transform.tag == "WallY")
      {
          x = 0;
          y = 1;

          collision = c.gameObject;

          force = transform.position - c.transform.position;
          print(force);
          fixedfoce = new Vector3(force.x * x, 0.0f, force.z * y);


          fixedfoce.Normalize();
          StartCoroutine(PushAwayXY());
      }
  }
  */

    public bool getHunting()
    {
        return hunting;
    }

    void Update()
    {

        if (pushing)
        {
            GetComponent<Rigidbody>().AddForce(fixedfoce * strenght);
            collision.GetComponent<Rigidbody>().AddForce(fixedfoce2 * strenght);
        }

        if (pushingxy)
        {
            GetComponent<Rigidbody>().AddForce(fixedfoce * strenght);
        }


    }


    private IEnumerator PushAway()
    {
       
            print("starting");
            pushing = true;
            pushing2 = true;
            yield return new WaitForSeconds(0.6f);

         
            print("midpart");
            pushing = false;
            gettinghit = false;
            hunting = false;

        if (gameObject.GetComponent<RusherHitsObject>() && gameObject.GetComponent<ProtoTypeEnemy>() && gameObject.GetComponent<RusherDamage>())
        {
            gameObject.GetComponent<RusherHitsObject>().enabled = true;
            gameObject.GetComponent<ProtoTypeEnemy>().enabled = true;
            gameObject.GetComponent<RusherDamage>().enabled = true;
        }
            
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            yield return new WaitForSeconds(0.3f);

            if (collision.gameObject.GetComponent<RusherHitsObject>() && collision.gameObject.GetComponent<ProtoTypeEnemy>() && collision.gameObject.GetComponent<RusherDamage>())
        {
            collision.gameObject.GetComponent<RusherHitsObject>().enabled = true;
            collision.gameObject.GetComponent<ProtoTypeEnemy>().enabled = true;
            collision.gameObject.GetComponent<RusherDamage>().enabled = true;
        }
          

              
                collision.GetComponent<Rigidbody>().useGravity = true;



                yield return new WaitForSeconds(0.4f);


          
           
              pushing2 = false;
              if(gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>())
              gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

        if (collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>())
            collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                print("end");

            }



        }
    

 /*   private IEnumerator PushAwayXY()
    {
        print("starting");
        pushingxy = true;

        yield return new WaitForSeconds(0.2f);
        pushingxy = false;
        gettinghit = false;
        hunting = false;
        print("end");

        gameObject.GetComponent<RusherHitsObject>().enabled = true;
        gameObject.GetComponent<ProtoTypeEnemy>().enabled = true;
        gameObject.GetComponent<FallInHolEnemy>().enabled = true;
        gameObject.GetComponent<RusherDamage>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
       
        yield return new WaitForSeconds(0.4f);

        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        
    }
}
*/
