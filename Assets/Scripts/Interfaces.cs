using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	void Damage(HitData hit);
	
}

public struct HitData
{
	public float damage;
	public GameObject other;

	public HitData(float d, GameObject othr)
	{
		damage = d;
		other = othr;
	}
}
