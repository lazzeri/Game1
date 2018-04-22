using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusherDamage : MonoBehaviour {

    GameObject Player;
    bool pushing = false;
    public float magnitude = 10f;
    public float strenght;
    public GameObject collision = null;
    private Animator anim;
    Vector3 force;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Robo-Mainchar");
        anim = Player.GetComponent<Animator>();
	}
    void OnCollisionEnter(Collision c)
    {
        collision = c.gameObject; 
        // calculate force vector
         force = c.transform.position - transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
         StartCoroutine(PushAway());
        
    }


    // Upaaadate is called once per frame
    void Update () {
        if(pushing)
        {
           
            collision.GetComponent<Rigidbody>().AddForce(force * strenght);
            print("LOL");

           
        }
            
    }

    private IEnumerator PushAway()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        pushing = true;
        anim.Play("Damage");
        yield return new WaitForSeconds(0.3f);
        pushing = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
}
