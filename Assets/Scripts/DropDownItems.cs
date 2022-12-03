using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownItems : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AnimationClass GetAnimation;
    private int index;
    private void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> list = new List<string>();
        for (int i = 0; i < gameManager.allObjects.Length; i++)
        {
            list.Add(gameManager.allObjects[i].name);
        }
        foreach (var item in list)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
        DropDownItemSelected(dropdown);
        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });
    }
    private void DropDownItemSelected(Dropdown dropdown)
    {
         index = dropdown.value;
        for (int i = 0; i < gameManager.allObjects.Length; i++)
        {
            gameManager.allObjects[i].SetActive(false);
        }
        gameManager.allObjects[index].gameObject.SetActive(true);        
    }
   
    public void AnimationOn()
    {        
       GetAnimation.AnimationOn(index);
    }
    public void AnimationOff()
    {
        GetAnimation.AnimationOff(index);
    }
}
