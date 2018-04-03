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


    private void Start()
    {
        _enemies = new List<Enemy>();
    }

    private void Update()
    {
        _enemyTimer -= Time.deltaTime;
        if (_enemyTimer <= 0)
        {
            Spawn();
            _enemyTimer = timeToSpawnEnemy;
        }
    }

    private void Spawn()
    {
        Enemy spawnedEnemy = GetNextEnemy();
        if (spawnedEnemy != null)
        {
			spawnedEnemy.gameObject.SetActive(true);
        }
		spawnedEnemy.Setup(
            enemySpawn.transform.position,
            playerBase.transform.position,
            spawnedEnemy.maxHealth);
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
}
