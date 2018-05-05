using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusherDamage : MonoBehaviour {

    GameObject Player;
    bool pushing = false;
    public float strenght;
    public GameObject collision = null;
    private Animator anim;
    Vector3 force;
    Vector3 fixedfoce;
    bool gettinghit;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Robo-Mainchar");
        anim = Player.GetComponent<Animator>();
        gettinghit = false;
	}
    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "Player")
        {
            
            collision = c.gameObject;
            // calculate force vector
            force = c.transform.position - transform.position;
            fixedfoce = new Vector3(force.x, 0.0f, force.z);
            // normalize force vector to get direction only and trim magnitude
            fixedfoce.Normalize();
            StartCoroutine(PushAway());
        }
     
        
    }


    // Upaaadate is called once per frame
    void Update () {
        if(pushing)
        {
           
            collision.GetComponent<Rigidbody>().AddForce(fixedfoce * strenght);
            

           
        }
            
    }

    private IEnumerator PushAway()
    {
        if(!gettinghit)
        PlayerHealth.PlayerHealthcount--;
        print(PlayerHealth.PlayerHealthcount);
        gettinghit = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        pushing = true;
        anim.Play("Damage");
        yield return new WaitForSeconds(0.6f);
        pushing = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        gettinghit = false;
    }
}
