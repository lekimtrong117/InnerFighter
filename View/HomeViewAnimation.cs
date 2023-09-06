using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeViewAnimation : BaseViewAnimation
{
   public Animator animator;
    private Action callback;
    public YenaDataBiding YenaDataBiding;

    void Awake()
    {
     animator=GetComponent<Animator>();   
        
    }
    public void EndInAnim()
    {

    }
    public void EndOutAnim()
    {
        
        callback?.Invoke();
    }    
    public override void OnShowViewAnimation(Action callback)
    {
        
        this.callback = callback;
        animator.Play("In");
        YenaDataBiding.Sit = true;
        callback?.Invoke();
        
    }
    public override void OnHideViewAnimation(Action callback)
    {
        this.callback = callback;
        animator.Play("Out", 0);
        YenaDataBiding.Meditate = true;
    }
}
