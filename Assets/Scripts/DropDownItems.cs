using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownItems : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private AnimatorStateInfo currentBaseState;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorSphere;
    [SerializeField] private Animator animatorCilindre;
    static private int IdleState = Animator.StringToHash("Base Layer.Empty");
    private int index;
    private void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);

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
        if (gameManager.allObjects[index].gameObject.name == "Cube" && gameManager.allObjects[index].gameObject.activeSelf == true)
        {
            animator.SetTrigger("TriggerOnCube");
        }
        else if (gameManager.allObjects[index].gameObject.name=="Sphere" && gameManager.allObjects[index].gameObject.activeSelf == true)
        {
            animatorSphere.SetTrigger("TreiggerOnSphere");
        }
        else if (gameManager.allObjects[index].gameObject.name == "cilindre" && gameManager.allObjects[index].gameObject.activeSelf == true)
        {
            animatorCilindre.SetTrigger("TriggerOnCilindre");
        }
    }
    public void AnimationOff()
    {
        animator.Play(IdleState);
        animatorSphere.Play(IdleState);
        animatorCilindre.Play(IdleState);
    }
}
