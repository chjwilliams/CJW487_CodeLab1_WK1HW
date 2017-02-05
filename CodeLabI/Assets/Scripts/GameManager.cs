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
    //  Public Static Variables
	public static GameManager gm;                //    Static referecne to GameManager

	//	Public Variable
	public float spawnDelay = 0.25f;             //    Spawn Delay for enemy's. Set to 1 in Inspector

    public int score = 0;                        //    Player's score
	public Transform spawnPoint0;                //    Referecne to the 0 Lane's SpawnPoint
	public Transform spawnPoint45;               //    Reference to the 45 Lane's SpawnPoint
	public Transform spawnPoint90;               //    Reference to the 90 Lane's SpawnPoint
	public Transform spawnPoint180;              //    Reference to the 180 Lane's SpawnPoint
	public Transform spawnPoint225;              //    Reference to the 225 Lane's SpawnPoint
	public Transform spawnPoint270;              //    Reference to the 270 Lane's SpawnPoint
	public Material activeMaterial;              //    Reference to the active material for the RTY buttons
	public Material inactiveMaterial;            //    Reference to the inactive material for the RTY buttons
	public ButtonControlScript rButton;          //    Reference to the R button's control script
	public ButtonControlScript tButton;          //    Reference to the T button's control script
    public ButtonControlScript yButton;          //    Reference to the Y button's control script
    public LaneControl degree0;                  //    Reference to the LaneControl Script of 0 Lane
	public LaneControl degree45;                 //    Reference to the LaneControl Script of 45 Lane
	public LaneControl degree90;                 //    Reference to the LaneControl Script of 90 Lane
	public LaneControl degree180;                //    Reference to the LaneControl Script of 180 Lane
	public LaneControl degree225;                //    Reference to the LaneControl Script of 225 Lane
    public LaneControl degree270;                //    Reference to the LaneControl Script of 270 Lane
    public List<EnemyContoller> enemyList;       //    List of all active enemies

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

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	DeactivateButtons: Sests the button materails to inactive                			*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
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
	/*	SpawnEnemy: Creates a new instance of the enemy prefab every spawnDelay seconds		*/
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

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	SetSpawnPoint: Sets spawn point for recently created enemy                    		*/
    /*			params: int id - Determines which lane the enemy goes in					*/
    /*																						*/
    /*			returns: 1 of 6 set spawn points											*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
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

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	SetEnemyLane: Tags enemy                                                       		*/
    /*			params: GameObject enemy - the enemy being tagged        					*/
    /*					int id - Determines which lane the enemy goes in					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
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

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	ButtonStatus: Destroys enemy on appropriate lanes. Increases score.           		*/
    /*			params: bool r - True if R is pressed.                   					*/
    /*					bool t - True if T is Pressed.                    					*/
    /*					bool y - True if Y is Pressed.                    					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void ButtonStatus(bool r, bool t, bool y)
	{
		DeactivateButtons ();

		if (SceneManager.GetActiveScene ().name == "Week1") 
		{
			if (!r && t && y) 
			{
				//	0 Degree
				UpdateScore (0);
			} 
			else if (r && t && !y) 
			{
				//	45 Degree
				UpdateScore (1);
			} 
			else if (!r && t && !y) 
			{
				//	90 Degree
		        UpdateScore (2);
			} 
			else if (r && !t && !y) 
			{
				//	180 Degree
				UpdateScore (3);
			} 
			else if (!r && !t && y)
			{
				//	225 Degree
				UpdateScore (4);
			} 
			else if (r && !t && y) 
			{
				//	270 Degree
				UpdateScore (5);
			}
		}
		else if (r & t & y)
		{
			SceneManager.LoadScene ("Week1", LoadSceneMode.Single);
		}
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	SetSpawnPoint: Sets spawn point for recently created enemy                    		*/
    /*			params: int id - Determines which lane the enemy goes in					*/
    /*																						*/
    /*			returns: 1 of 6 set spawn points											*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void UpdateScore(int id)
    {
        switch (id)
        {
            case 0:
                degree0.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy0")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;
            case 1:
                degree45.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy45")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;

            case 2:
                degree90.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy90")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;

            case 3:
                degree180.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy180")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;
            case 4:
                degree225.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy225")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;

            case 5:
                degree270.GetComponent <MeshRenderer> ().material = activeMaterial;
                foreach (EnemyContoller enemy in enemyList)
                {
                    if (enemy.tag == "Enemy270")
                    {
                        score++;
                        enemyList.Remove (enemy);
                        Destroy (enemy.gameObject);
                    }
                }
                break;
            default:
                break;
        }

    }
	
    /*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Update: Called once per frame														*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		ButtonStatus (rButton.isPressed, tButton.isPressed, yButton.isPressed);

	}
}
