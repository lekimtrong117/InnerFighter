using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenaDataBiding : CharacterDataBiding
{
    //drag in component
    public Animator animator;
    //hash
    int normalAttackHash;
    int spellAttackHash;
    int DashHash;
    int runHash;
    int ultimateHash;
    int meditateHash;
    int sitHash;
    int darkReleaseHash;
    // generate  animator control key
    public float Run
    {
        set
        {
            animator.SetFloat(runHash, value);
        }
    }
    public bool normalAttack
    {
        set
        {
            if (value)
                animator.SetTrigger(normalAttackHash);
        }
    }
    public bool Sit
    {
        set
        {
            if (value)
                animator.SetTrigger(sitHash);
        }
    }
    public bool Meditate
    {
        set
        {
            if (value)
                animator.SetTrigger(meditateHash);
        }
    }
    public bool DarkRelease
    {
        set
        {
            if (value)
                animator.SetTrigger(darkReleaseHash);
        }
    }
    public bool spellAttack
    {
        set
        {
            if (value)
                animator.SetTrigger(spellAttackHash);
        }
    }
    public bool Dash
    {
        set
        {
            if (value)
                animator.SetTrigger(DashHash);
        }
    }
    public bool ultimate
    {
        set
        {
            if (value)
                animator.SetTrigger(ultimateHash);
        }
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
        //StringtoHash
        runHash = Animator.StringToHash("Run");
        spellAttackHash = Animator.StringToHash("SpellAttack");
        normalAttackHash = Animator.StringToHash("NormalAttack");
        DashHash = Animator.StringToHash("Dash");
        ultimateHash = Animator.StringToHash("Ultimate");
        sitHash = Animator.StringToHash("Sit");
       meditateHash = Animator.StringToHash("Meditate");
        darkReleaseHash= Animator.StringToHash("DarkRelease");
    }
}
