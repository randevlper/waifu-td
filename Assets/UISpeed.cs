using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeed : MonoBehaviour {
	[SerializeField]
	private Text t;

	public void SetText(float num)
	{
		t.text = "Speed: " + num;
	}
}
