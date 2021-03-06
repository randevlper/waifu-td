﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Wave
{
    public int countEnemies;
    public float enemyHealth;
    public float spawnrate;
}

public class GameManager : MonoBehaviour
{

    static public GameManager current;
    public bool isPlayerDead;
    public float playerHealth;
    private float _timeScale;
	public UISpeed uiSpeed;
    public float TimeScale
    {
        get { return _timeScale; }
        set
        {
            _timeScale = Mathf.Clamp(value,0,100);
            Time.timeScale = _timeScale;
			uiSpeed.SetText(_timeScale);
        }
    }

    public AnimationCurve enemyHealthOverTime;

    public Wave[] waves;

    private void Awake()
    {
        if (current == null)
        {
			_timeScale = 1;
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
