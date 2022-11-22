using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] public GameObject[] allObjects;
    [SerializeField] public GameObject[] objects;
    [SerializeField] private Text textName;

    private bool changedVisible = true;
    private void Update()
    {
        VisibleObjects();
    }
    private void VisibleObjects()
    {

        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            textName.text = hit.collider.gameObject.name;
        }
        if (Input.GetKeyDown(KeyCode.V) && changedVisible == true)
        {
            changedVisible = false;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.V) && changedVisible == false)
        {
            changedVisible = true;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].gameObject.SetActive(true);
            }
        }
    }
    

}
