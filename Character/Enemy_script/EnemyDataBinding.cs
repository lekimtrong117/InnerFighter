using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataBinding : CharacterDataBiding
{
    //dragin component
    public Animator animator;
    //hash
    private int meleeHash;
    private int dieHash;
    private int throwHash;
    private int runHash;
    private int stunnedHash;
    private int shootHash;
    int attackHash;
    int aimHash;
    int chargerHash;
    int idleHash;
    //animator param
    public bool Charge
    {
        set
        {
            if (value)
                animator.SetTrigger(chargerHash);
        }
    }

         public bool Idle
    {
        set
        {
            if (value)
                animator.SetTrigger(idleHash);
        }
    }
    public bool Shoot
    {
        set
        {
            if (value)
                animator.SetTrigger(shootHash);
        }
    }
    public float Run
    {
        set
        {
            animator.SetFloat(runHash, value);
        }
    }
    public bool Stun
    {
        set
        {
            if(value)
            animator.SetTrigger(stunnedHash);
        }
    }
    public bool Die
    {
        set
        {
            if (value)
                animator.SetTrigger(dieHash);
        }
    }
    public bool Melee
    {
        set
        {
            if(value)
            animator.SetTrigger(meleeHash);
        }
    }
    public bool Throw
    {
        set
        {
            if (value)
                animator.SetTrigger(throwHash);
        }
    }
    public bool Aim
    {
        set
        {
            if (value)
                animator.SetTrigger(aimHash);
        }
    }
    public bool Attack
    {
        set
        {
            if (value)
                animator.SetTrigger(attackHash);
        }
    }
    public virtual void Awake()
    {
        // initial
        animator = gameObject.GetComponent<Animator>();
        // string to hash
        meleeHash = Animator.StringToHash("Melee");
        dieHash = Animator.StringToHash("Die");
        throwHash = Animator.StringToHash("Throw");
        stunnedHash = Animator.StringToHash("Stun");
        runHash = Animator.StringToHash("Run");
        shootHash = Animator.StringToHash("Shoot");
        aimHash= Animator.StringToHash("Aim");
        attackHash = Animator.StringToHash("Attack");
        chargerHash = Animator.StringToHash("Charge");
            idleHash= Animator.StringToHash("Idle");
    }
}
