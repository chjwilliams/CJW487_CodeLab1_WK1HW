using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	ScoreKeeper: Updates Score                                    						*/
/*																						*/
/*		Functions:																		*/
/*			void Start ()																*/
/*			void Update ()																*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class ScoreKeeper : MonoBehaviour
{
    public Text score;
    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Start ()
    {
        score = GetComponent <Text> ();

    }
	
    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
    void Update ()
    {
        score.text = "Score: " + GameManager.gm.score;
    }
}
