using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Wave
{
	public float countEnemies;
	public float enemyHealth;
}

public class GameManager : MonoBehaviour {

	static public GameManager current;
	public bool isPlayerDead;
	public float playerHealth;

	[RangeAttribute(0,10)]
	public float timeScale;

	public AnimationCurve enemyHealthOverTime;

	private void Start()
	{
		if(current == null)
		{
			isPlayerDead = false;
			current = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
	}

	private void Update()
	{
		//Time.timeScale = timeScale;
	}
	public void ResetGame()
	{
		SceneManager.LoadSceneAsync(0);
		Time.timeScale = 1;
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
