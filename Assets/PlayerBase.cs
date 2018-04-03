using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public BoxCollider col;
    public LayerMask mask;
	public float health;

    private void Update()
    {
		CheckCollision();
    }

    void CheckCollision()
    {
        foreach (Collider item in GetOverlappedColliders())
        {
            Enemy other = item.gameObject.GetComponent<Enemy>();
            if (other != null)
            {
                other.gameObject.SetActive(false);
            }
        }
    }

	Collider[] GetOverlappedColliders()
	{
		return Physics.OverlapBox(
			transform.position, 
			col.bounds.extents, 
			Quaternion.identity, 
			mask);
	}
}
