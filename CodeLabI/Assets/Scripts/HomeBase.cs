using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HomeBase : MonoBehaviour
{
	public float radius = 2.18204f;
	public float moveSpeed = 5.0f;
	public float health = 10.0f;
	public float duration = 5.0f;
	public Color startColor;
	public Color endColor;

	private Color color;
	private float t;
	// Use this for initialization
	void Start () 
	{
		color = GetComponent<MeshRenderer> ().material.color;
	}

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
