using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	public float moveSpeed = 4.0f;            //    Eney's movement speed
	public float slopeOfLane = 0.5f;          //    Slope of lane to enemy travels along the line
	public HomeBase homebase;                 //    Reference to Enemy's target

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Start ()
	{
		homebase = GameObject.Find ("Home").GetComponent<HomeBase>();
	}


    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Move: Moves enemy according to tag                                					*/
    /*		param: string enemytag - gameobject's tag										*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Move(string enemytag)
	{
		if (enemytag == "Enemy0")
		{
			transform.position = new Vector3(transform.position.x - slopeOfLane * moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z + slopeOfLane * moveSpeed * Time.deltaTime);
		}
		else if (enemytag == "Enemy45")
		{
			transform.position = new Vector3(transform.position.x + slopeOfLane  * -moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z);
		}
		else if (enemytag == "Enemy90")
		{
			transform.position = new Vector3(transform.position.x - slopeOfLane * moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z - slopeOfLane * moveSpeed * Time.deltaTime);
		}
		else if (enemytag == "Enemy180")
		{
			transform.position = new Vector3(transform.position.x + slopeOfLane * moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z - slopeOfLane * moveSpeed * Time.deltaTime);
		}
		else if (enemytag == "Enemy225")
		{
			transform.position = new Vector3(transform.position.x + slopeOfLane * moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z);
		}
		else if (enemytag == "Enemy270")
		{
			transform.position = new Vector3(transform.position.x + slopeOfLane * moveSpeed * Time.deltaTime,
											transform.position.y, 
											transform.position.z + slopeOfLane * moveSpeed * Time.deltaTime);
		}
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Update ()
	{
		Move (tag);

		if(Vector3.Distance(transform.position, homebase.transform.position) < homebase.radius)
		{
		    homebase.SendMessage ("Damage");

		    Destroy (gameObject);
		}
	}
}
