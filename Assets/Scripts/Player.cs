using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class Player : MonoBehaviour
{

    public Camera currentCamera;
    public GameObject towerPrefab;
    public GameObject pauseMenu;
    public LayerMask mask;

    private void Start()
    {
		pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !pauseMenu.activeInHierarchy)
        {
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue,mask))
            {
                SpawnTower(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UIPauseMenu.current.TogglePauseMenu();
        }
    }

    void SpawnTower(Vector3 pos)
    {
        Instantiate(towerPrefab, pos, Quaternion.identity);
    }
}
