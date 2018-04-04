using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Has a list of enemies
    //Has a list of enemy prefabs
    //Spawns enemies based on a rate modified by delta time
    //Tells the enemies where to go

    private List<Enemy> _enemies;

    private float _enemyTimer;

    public Transform enemySpawn;
    public Transform playerBase;
    public float timeToSpawnEnemy;
    public GameObject enemyPrefab;
    int _waveNum = 0;
    int _enemiesToSpawn;
    float _enemiesHealth;
    bool waiting;
    public float waitTime;

    public UIWave uiWave;

    private void Start()
    {
        _enemies = new List<Enemy>();
        _enemiesHealth = GameManager.current.waves[0].enemyHealth;
        _enemiesToSpawn = GameManager.current.waves[0].countEnemies;
        uiWave.SetWave(_waveNum + 1);
    }

    private void Update()
    {
        _enemyTimer -= Time.deltaTime;
        Wave();
    }

    private void Wave()
    {
        if (_enemiesToSpawn > 0)
        {
            if (_enemyTimer <= 0)
            {
                Spawn();
                _enemyTimer = timeToSpawnEnemy;
                _enemiesToSpawn--;
            }
        }

        if (IsAllDead() && _enemiesToSpawn <= 0 && !waiting)
        {
            waiting = true;
            Invoke("WaitToStartNextWave", waitTime);
        }
    }

    private void WaitToStartNextWave()
    {
        _waveNum++;

        if (_waveNum < GameManager.current.waves.Length)
        {
            uiWave.SetWave(_waveNum + 1);
            _enemiesHealth = GameManager.current.waves[_waveNum].enemyHealth;
            _enemiesToSpawn = GameManager.current.waves[_waveNum].countEnemies;
            waiting = false;
        }
        else
        {
            UIPauseMenu.current.TogglePauseMenu();
            UIPauseMenu.current.continueButton.SetActive(false);
            //Endgame
        }
    }

    private void Spawn()
    {
        Enemy spawnedEnemy = GetNextEnemy();
        if (spawnedEnemy != null)
        {
            spawnedEnemy.Setup(
                enemySpawn.transform.position,
                playerBase.transform.position,
                _enemiesHealth);
            spawnedEnemy.gameObject.SetActive(true);
            spawnedEnemy.Destination = playerBase.transform.position;
        }
    }

    private Enemy GetNextEnemy()
    {
        Enemy retval = null;

        for (int i = 0; i < _enemies.Count; ++i)
        {
            if (!_enemies[i].gameObject.activeInHierarchy)
            {
                return _enemies[i];
            }
        }

        retval = Instantiate(
            enemyPrefab,
            enemySpawn.transform.position,
            Quaternion.identity, transform).GetComponent<Enemy>();
        _enemies.Add(retval);

        return retval;
    }

    private bool IsAllDead()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
