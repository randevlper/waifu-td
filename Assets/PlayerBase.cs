using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public BoxCollider col;
    public LayerMask mask;
	public int health;
	public UIHealth uiHealth;
	public UIPauseMenu uiPauseMenu;

	private void Start()
	{
		uiHealth.SetHealth(health);
	}
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
				health--;
				uiHealth.SetHealth(health);
				if(health <= 0)
				{
					Time.timeScale = 0;
					GameManager.current.isPlayerDead = true;
					uiPauseMenu.TogglePauseMenu();
					uiPauseMenu.continueButton.SetActive(false);
				}
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
