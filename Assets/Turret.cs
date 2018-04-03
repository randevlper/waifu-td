using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject head;

    public float firingDistance;
    public float damage;
    public float fireRate;
    private float _fireTimer;
	public LayerMask mask;

	private Enemy attackingEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _fireTimer -= Time.deltaTime;

		if(_fireTimer <= 0)
		{
			Fire();
			_fireTimer = fireRate;
		}
		if(attackingEnemy != null)
		{
			Track();
		}

        //If see enemy, track it
    }

	void Fire()
	{
		foreach(Collider item in GetOverlappedColliders())
		{
			//Debug.Log(item);
			IDamageable damageble = item.GetComponent<IDamageable>();
			if(damageble != null)
			{
				attackingEnemy = item.GetComponent<Enemy>();
				damageble.Damage(new HitData(damage,gameObject));
				Track();
			}
		}
	}

	void Track()
	{
		head.transform.LookAt(attackingEnemy.transform);
	}

    Collider[] GetOverlappedColliders()
    {
        return Physics.OverlapSphere(
            transform.position,
            firingDistance,
            mask);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position,firingDistance);
	}

}
