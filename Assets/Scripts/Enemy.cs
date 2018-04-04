using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
	float _health;
	public float maxHealth;

	public float Health
	{
		get{return _health;}
		set{_health = value;}
	}

	public Rigidbody rb;
	public NavMeshAgent navMeshAgent;

	public float Speed
	{
		get{return navMeshAgent.speed;}
		set{navMeshAgent.speed = value;}
	}
	public Vector3 Destination
	{
		get{return navMeshAgent.destination;}
		set{navMeshAgent.destination = value;}
	}

    // // Use this for initialization
    // void Start()
    // {
    // }

    // // Update is called once per frame
    // void Update()
    // {
    // }

    public void Damage(HitData hit)
    {
		if (hit.damage > 0)
		{
			Health -= hit.damage;

			if(_health < 0)
			{
				Death();
			}
		}
    }

	void Death()
	{
		gameObject.SetActive(false);
	}

	public void Setup(Vector3 pos, Vector3 dest, float hel)
	{
		transform.position = pos;
		Health = hel;
	}
}
