using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerActionButton : MonoBehaviour 
{

		void Start () 
	{
		
	}
	
	
	void Update () 
	{
		print(CrossPlatformInputManager.GetButton("Action"));
	}
}
