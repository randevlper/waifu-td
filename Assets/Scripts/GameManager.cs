using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager current;
	public float playerHealth;

	private void Start()
	{
		if(current == null)
		{
			current = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
