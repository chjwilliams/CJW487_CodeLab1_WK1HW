using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	HomeBase: manages state of homebase                            						*/
/*																						*/
/*		Functions:																		*/
/*			void Damage ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class HomeBase : MonoBehaviour
{
	public float radius = 2.18204f;            //    Radius of homebase
	public float moveSpeed = 5.0f;             //    How fast home base move down
	public float health = 10.0f;               //    Amount of health points

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Damage: Takes one health point away from home base.                                 */
    /*            Starts game over when helath is 0                				        	*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Damage()
	{
		if (health < 1)
		{
			health = 0;
			SceneManager.LoadScene ("StartScreen", LoadSceneMode.Single);
		}
		else
		{
			health--;
			transform.Translate (Vector3.down * moveSpeed * Time.deltaTime);
		}
	}
}
