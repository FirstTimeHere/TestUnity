using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClass : MonoBehaviour
{
    [SerializeField] private Animator[] animationClips;
    static private int IdleState = Animator.StringToHash("Base Layer.Empty");
    static private int trigger = 0;
    public void AnimationOn(int index)
    {
        if (index == animationClips.Length)
        {
            Debug.Log("Ошибка, не добавлена анимация");
        }
        else
        {
            trigger = animationClips[index].GetParameter(0).nameHash;
            animationClips[index].SetTrigger(trigger);
        }
    }
    public void AnimationOff(int index)
    {
        animationClips[index].Play(IdleState);
    }
}
