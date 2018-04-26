using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
   
    public static int PlayerHealthcount;
	void Start () {
       
        PlayerHealthcount = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerHealthcount == 0)
        {
            
            PlayerDeath.Die();
        }
	}



    
}
