using UnityEngine;
using System.Collections;

public class GoalMoveScript : MonoBehaviour 
{

	//	Public Variables
	public float moveMod;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (
			moveMod * ((Mathf.PerlinNoise(Time.timeSinceLevelLoad, 0) - 0.5f) * 2),
			moveMod * ((Mathf.PerlinNoise(Time.timeSinceLevelLoad, 0) - 0.5f) * 2),
			0));
	}
}
