using UnityEngine;
using System.Collections;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	PlayerControllerScript: Controls the player											*/
/*																						*/
/*		Functions:																		*/
/*			void Start ()																*/
/*			void Move (KeyCode key)														*/
/*			void Update ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class ButtonControlScript : MonoBehaviour 
{

	//	Public Variables
	public bool isPressed;						//	Returns true if button is pressed
	public float moveSpeed;						//	Move speed of the player
	public KeyCode downKey;						//	Down Key for the player
	public Material activeMaterial;				//	Material shown when active
	public Material inactiveMaterial;			//	Material shown when inactive

	//	Private Variables
	private Vector3 _OriginalPosition;			//	Referece to button's original position
	private MeshRenderer _MeshRenderer;			//	Reference to the button's mesh renderer

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Start: Runs once at the begining of the game initalizes variables.					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Start () 
	{
		_OriginalPosition = transform.position;
		_MeshRenderer = GetComponent<MeshRenderer> ();
	}
		
	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Move: Moves the player																*/
	/*		param: 	Vector 3 direction - 													*/
	/*				KeyCode key - the key that was presssed									*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Move (KeyCode key)
	{
		
		if (Input.GetKeyDown (key))
		{
			isPressed = true;
			transform.Translate (Vector3.down * moveSpeed * Time.deltaTime);
			_MeshRenderer.material = activeMaterial;
		}

		if (Input.GetKeyUp(key))
		{
			isPressed = false;
			transform.position = new Vector3 (_OriginalPosition.x, _OriginalPosition.y, _OriginalPosition.z);
			_MeshRenderer.material = inactiveMaterial;
		}
	}
	
	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Update: Called once per frame														*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		Move (downKey);
	}
}
