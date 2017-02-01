using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	GameManager: manages game state	and state of all buttons							*/
/*																						*/
/*		Functions:																		*/
/*			void Start ()																*/
/*			void Move (KeyCode key)														*/
/*			void Update ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class GameManager : MonoBehaviour 
{
	public static GameManager gm;

	//	Public Variable
	public float spawnDelay = 0.25f;
	public Transform spawnPoint0;
	public Transform spawnPoint45;
	public Transform spawnPoint90;
	public Transform spawnPoint180;
	public Transform spawnPoint225;
	public Transform spawnPoint270;
	public Material activeMaterial;
	public Material inactiveMaterial;
	public ButtonControlScript rButton;
	public ButtonControlScript tButton;
	public ButtonControlScript yButton;
	public LaneControl degree0;
	public LaneControl degree45;
	public LaneControl degree90;
	public LaneControl degree180;
	public LaneControl degree225;
	public LaneControl degree270;
	public List<EnemyContoller> enemyList;

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Start: Runs once at the begining of the game initalizes variables.					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Start () 
	{
		if (gm == null)
		{
			gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
		}

		if (SceneManager.GetActiveScene ().name == "Week1") 
		{
			StartCoroutine (SpawnEnemy ());
		}
	}

	void DeactivateButtons()
	{
		degree0.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		degree45.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		degree90.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		degree180.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		degree225.GetComponent<MeshRenderer> ().material = inactiveMaterial;
		degree270.GetComponent<MeshRenderer> ().material = inactiveMaterial;
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	RespawnPlayer: Creates a new instance of the player prefab							*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	public IEnumerator SpawnEnemy()
	{
		yield return new WaitForSeconds (spawnDelay);

		int enemyID = Random.Range (0, 100) % 6;
		GameObject newEnemy = (GameObject)Instantiate (PrefabManager.Instance.EnemyPrefab, SetSpawnPoint (enemyID).position,SetSpawnPoint (enemyID).rotation);
		SetEnemyLane (newEnemy, enemyID);
		enemyList.Add (newEnemy.GetComponent<EnemyContoller> ());
		StartCoroutine (SpawnEnemy());
	
	}

	Transform SetSpawnPoint(int id)
	{
		if (id == 0)
		{
			return spawnPoint0;

		}
		else if (id == 1)
		{
			return spawnPoint45;

		}
		else if (id == 2)
		{
			return spawnPoint90;
		}
		else if (id == 3)
		{
			return spawnPoint180;
		}
		else if (id == 4)
		{
			return spawnPoint225;
		}
		else
		{
			return spawnPoint270;
		}
	}

	void SetEnemyLane(GameObject enemy, int id)
	{
		if (id == 0)
		{
			enemy.tag = "Enemy0";

		}
		else if (id == 1)
		{
			enemy.tag = "Enemy45";

		}
		else if (id == 2)
		{
			enemy.tag = "Enemy90";
		}
		else if (id == 3)
		{
			enemy.tag = "Enemy180";
		}
		else if (id == 4)
		{
			enemy.tag = "Enemy225";
		}
		else
		{
			enemy.tag = "Enemy270";
		}
	}

	void ButtonStatus(bool r, bool t, bool y)
	{
		DeactivateButtons ();

		if (SceneManager.GetActiveScene ().name == "Week1") 
		{
			if (!r && t && y) 
			{
				//	0 Degree
				degree0.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy0") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}

			} 
			else if (r && t && !y) 
			{
				//	45 Degree
				degree45.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy45") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}
			} 
			else if (!r && t && !y) 
			{
				//	90 Degree
				degree90.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy90") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}
			} 
			else if (r && !t && !y) 
			{
				//	180 Degree
				degree180.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy180") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}
			} 
			else if (!r && !t && y)
			{
				//	225 Degree
				degree225.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy225") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}
			} 
			else if (r && !t && y) 
			{
				//	270 Degree
				degree270.GetComponent<MeshRenderer> ().material = activeMaterial;
				foreach (EnemyContoller enemy in enemyList) 
				{
					if (enemy.tag == "Enemy270") 
					{
						enemyList.Remove (enemy);
						Destroy (enemy.gameObject);
					}
				}
			}
		}
		else if (r & t & y)
		{
			SceneManager.LoadScene ("Week1", LoadSceneMode.Single);
		}
	}
	
	//*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Update: Called once per frame														*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		ButtonStatus (rButton.isPressed, tButton.isPressed, yButton.isPressed);

	}
}
