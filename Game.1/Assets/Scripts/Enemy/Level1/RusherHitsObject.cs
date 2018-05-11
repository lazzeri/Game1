using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RusherHitsObject : MonoBehaviour {
    
    public bool hunting;
    bool start;
    GameObject Player;
    public GameObject OtherPlayer;
    bool pushing = false;
    public float strenght = 10f;
    public GameObject collision = null;
    private Animator anim;
    Vector3 force,force2, fixedfoce2;
    Vector3 fixedfoce;
    bool gettinghit;
	bool xd = false;
    private ProtoTypeEnemy scProto;
    private FallInHolEnemy scFallinHole;
    private RusherDamage scRusher;
    private GameObject Enemy;
    int x = -1;
    int y = -1;
	public  int t = -1;
	public  int u = -1;
    // Use this for initialization
    void Start () {
        hunting = false;
        start = false;
		scProto = this.GetComponent<ProtoTypeEnemy>();
		scFallinHole = this.GetComponent<FallInHolEnemy>();
        scRusher = this.GetComponent<RusherDamage>();
    }
	
	// Update is called once per frame
	
    void OnCollisionEnter(Collision c)
    {
	
		if (c.transform.tag == "Rusher" && c.gameObject.GetComponent<RusherHitsObject>().getHunting() == false)
        {
          
            print("GO");
			hunting = true;
            c.gameObject.GetComponent<RusherHitsObject>().enabled = false;
            c.gameObject.GetComponent<ProtoTypeEnemy>().enabled = false;
            c.gameObject.GetComponent<FallInHolEnemy>().enabled = false;
            c.gameObject.GetComponent<RusherDamage>().enabled = false;
            c.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            gameObject.GetComponent<ProtoTypeEnemy>().enabled = false;
            gameObject.GetComponent<FallInHolEnemy>().enabled = false;
            gameObject.GetComponent<RusherDamage>().enabled = false;
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            print("lol");
            print("hit");

            force = c.transform.position - transform.position;
			fixedfoce = new Vector3(force.x *-2, 0.0f, force.z *-2);
		    fixedfoce.Normalize();
        
		    force2 = transform.position - c.transform.position;
			fixedfoce2 = new Vector3(force2.x *-2, 0.0f, force2.z *-2);
		    fixedfoce2.Normalize();
        
			collision = c.gameObject;
			StartCoroutine(PushAway());
        }

        if (c.transform.tag == "WallX")
        {
            x = 1;
            y = 0;

            print("hit");
            collision = c.gameObject;
            // calculate force vector
            //   force = c.transform.position - transform.position;
            force = transform.position - c.transform.position;
            print(force);
            fixedfoce = new Vector3(force.x * x, 0.0f, force.z * y);
            // normalize force vector to get direction only and trim magnitude
            fixedfoce.Normalize();
            StartCoroutine(PushAway());
        }

        if (c.transform.tag == "WallY")
        {
            x = 0;
            y = 1;

            print("hit");
            // calculate force vector
            //   force = c.transform.position - transform.position;
            force = transform.position - c.transform.position;
            print(force);
            fixedfoce = new Vector3(force.x * x, 0.0f, force.z * y);
            // normalize force vector to get direction only and trim magnitude
            fixedfoce.Normalize();
            StartCoroutine(PushAway());
        }
	}


    public bool getHunting()
    {
        return hunting;
    }
    void Update()
    {
		if(pushing)
		{
			GetComponent<Rigidbody>().AddForce(fixedfoce * strenght);
			collision.GetComponent<Rigidbody>().AddForce(fixedfoce2 * strenght);
		}
	}
    

    private IEnumerator PushAway()
    {
        print("starting");
        pushing = true;
        scProto.enabled = false;
        scFallinHole.enabled = false;
        scRusher.enabled = false;
        yield return new WaitForSeconds(0.6f);
        pushing = false;
        gettinghit = false;
        hunting = false;
        print("end");

		gameObject.GetComponent<RusherHitsObject>().enabled = true;
		gameObject.GetComponent<ProtoTypeEnemy>().enabled = true;
		gameObject.GetComponent<FallInHolEnemy>().enabled = true;
		gameObject.GetComponent<RusherDamage>().enabled = true;
      
		Enemy.gameObject.GetComponent<RusherHitsObject>().enabled = true;
        Enemy.gameObject.GetComponent<ProtoTypeEnemy>().enabled = true;
        Enemy.gameObject.GetComponent<FallInHolEnemy>().enabled = true;
        Enemy.gameObject.GetComponent<RusherDamage>().enabled = true;
		

        yield return new WaitForSeconds(0.6f);

        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        Enemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
	}
}
