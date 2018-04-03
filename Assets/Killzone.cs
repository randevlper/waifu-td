using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

	public float radius;
	public LayerMask mask;
	public float damage;

	void Update () {
		DealDamage();
	}

	void DealDamage()
	{
		foreach(Collider item in GetOverlappedBodies())
		{
			IDamageable damageable = item.gameObject.GetComponent<IDamageable>();
			if(damageable != null)
			{
				damageable.Damageable(new HitData(damage,gameObject));
			}
		}
	}

	Collider[] GetOverlappedBodies()
	{
		return Physics.OverlapSphere(transform.position,radius);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,radius);
	}
}
