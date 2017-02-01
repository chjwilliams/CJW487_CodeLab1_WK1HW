using UnityEngine;
using System.Collections;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	PlayerDestroyScript: Destroys the player											*/
/*																						*/
/*		Functions:																		*/
/*			void Start ()																*/
/*			void Update ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class PlayerDestoryScript : MonoBehaviour 
{

	//	Public Variables
	public float  edge;
	public GameObject goal;

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Start: Runs once at the begining of the game initalizes variables.					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Start () 
	{
		goal = GameObject.Find ("Goal");	
	}
	
	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Update: Called once per frame														*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		//if (Vector3.Distance (goal.transform.position, transform.position) > edge)
		//{
			//Destroy (gameObject);	
		//}
	}
}
