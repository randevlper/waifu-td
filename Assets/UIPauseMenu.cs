using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    static public UIPauseMenu current;
	public GameObject continueButton;
    private void Start()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TogglePauseMenu()
    {
        if (gameObject.activeInHierarchy && !GameManager.current.isPlayerDead)
        {
            gameObject.SetActive(false);
            Time.timeScale = GameManager.current.timeScale;
        }
        else
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

    }
}
