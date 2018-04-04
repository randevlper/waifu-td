using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWave : MonoBehaviour {

	[SerializeField]
	private Text t;

	public void SetWave(int num)
	{
		t.text = "Wave: " + num;
	}
}
