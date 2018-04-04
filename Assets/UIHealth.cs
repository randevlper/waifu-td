using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

	[SerializeField]
	private Text t;

	public void SetHealth(int health)
	{
		t.text = "❤ " + health;
	}
}
