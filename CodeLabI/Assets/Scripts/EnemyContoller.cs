using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	public float moveSpeed = 4.0f;
	public float slopeOfLane = 0.5f;
	public HomeBase homebase;

	// Use this for initialization
	void Start () 
	{
		homebase = GameObject.Find ("Home").GetComponent<HomeBase>();
	}



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
	
	// Update is called once per frame
	void Update () 
	{
		Move (tag);

		if(Vector3.Distance(transform.position, homebase.transform.position) < homebase.radius)
		{
			homebase.SendMessage ("Damage");
			Destroy(gameObject);
			Debug.Log ("done");
		}
	}
}
