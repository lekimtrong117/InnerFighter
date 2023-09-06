using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class YenaDashControl : MonoBehaviour
{
    Transform trans;
    //drag in component
    public Transform model;
    //m_var
    float runSpeedbeforeDash;
    float m_timer_dash_cooldown;
    int m_dashCount = 1;
    float currentDashCooldown;
    public SkillAction onSkillcast;

    // character params
    public float dashSpeed = 20;
    public float secondDashCoolDown = 0.15f;
    public float firstDashCooldown = 1;
    public float dash_immune_time = 0.2f;
    IEnumerator coroutine;
    public MyInput myInput;
    public void InitDash()
    {
        trans = transform;
        //Dash cooldown 
        currentDashCooldown = firstDashCooldown;
        m_timer_dash_cooldown = currentDashCooldown;
        m_dashCount = 1;
        //enable input
        myInput = new MyInput();
        myInput.Player.Enable();
        myInput.Player.Dash.performed += OnDashGamepad;
    }

    private void OnDestroy()
    {
        myInput.Player.Dash.performed -= OnDashGamepad;
    }

    void Awake()
    {
        InitDash();

    }
    void Update()
    {
        m_timer_dash_cooldown += Time.deltaTime;
        // reset current Dash cool down when usser dont use second Dash
        if (m_timer_dash_cooldown > 1f)
        {
            currentDashCooldown = firstDashCooldown;
            m_dashCount = 1;
        }
    }
    public void OnDashGamepad(InputAction.CallbackContext callbackContext)
    {
        OnDash();
    }
    public void OnDash()
    {
        // Dash omly available when character is running
        if ((Yena.Instance.moveController.leftJS.dirMoveJS.magnitude > 0 || myInput.Player.Movement.ReadValue<Vector2>().magnitude > 0) && Yena.Instance.attribute.IsMoveAble)
        {
            // Dash only available when not on cooldown
            if (m_timer_dash_cooldown >= currentDashCooldown)
            {
                if (m_dashCount == 1)
                {
                    m_timer_dash_cooldown = 0;
                    currentDashCooldown = secondDashCoolDown;
                    m_dashCount = 2;
                }
                else
                {
                    if (m_dashCount == 2)
                    {
                        m_timer_dash_cooldown = 0;
                        currentDashCooldown = firstDashCooldown;
                        m_dashCount = 1;
                    }
                }
                if (Yena.Instance.attribute.current_RunSpeed != dashSpeed)
                {
                    runSpeedbeforeDash = Yena.Instance.attribute.current_RunSpeed;
                }
                Yena.Instance.dataBiding.Dash = true;
                //immune
                Yena.Instance.attribute.IsDashImmune = true;
                if (coroutine != null)
                    StopCoroutine(coroutine);
                coroutine = DelayImmuneDash();
                StartCoroutine(coroutine);
                //audio
                Yena.Instance.audioSource.PlayOneShot(Yena.Instance.dash_sound);
                // cast point= yena foot
               
                if (Yena.Instance.NearestEnemy() != null)
                    onSkillcast.Invoke(Yena.Instance.leftFoot.position, Yena.Instance.NearestEnemy().trans.position);
                else
                    onSkillcast.Invoke(Yena.Instance.leftFoot.position, this.trans.position + this.trans.forward * 10);

            }
        }
    }
    public void OnDashAnimStart()
    {
        Yena.Instance.attribute.current_RunSpeed = dashSpeed;
    }
    public void OnDashAnimEnd()
    {
        Yena.Instance.attribute.current_RunSpeed = runSpeedbeforeDash;
    }
    IEnumerator DelayImmuneDash()
    {
        yield return new WaitForSeconds(dash_immune_time);
        Yena.Instance.attribute.IsDashImmune = false;
    }
    public void PopUpDeflect(Vector3 deflect_place)
    {
        PopUpTextControl pop_Up = PoolManager.Instance.Spawn("PopUpText").gameObject.GetComponent<PopUpTextControl>();
        pop_Up.SetUp(deflect_place, "DEFLECT", 15, Color.green);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            Projectile colliProjectile = collider.gameObject.GetComponent<Projectile>();
            if (colliProjectile.target_tag == Target_tag.Player)
            {
                if (colliProjectile.canbe_deflected && Yena.Instance.attribute.canDeflect)
                {
                    PopUpDeflect(colliProjectile.trans.position);
                    colliProjectile.SetUp(colliProjectile.trans.position, colliProjectile.damageData, Target_tag.Enemy, false, false);
                    // deflected project will reverse direction and fly with delfected_fly_speed , not before speed
                    colliProjectile.FlyTo(colliProjectile.trans.position - colliProjectile.trans.forward * 30, 40, 30);
                }
            }

        }

    }
}
