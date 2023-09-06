using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RootMotion.FinalIK;
using UnityEngine.InputSystem;

public class PlayerMovementControl : MySingleton<PlayerMovementControl>
{
//    Transform trans;
//    public float mainCharacterSpeed = 20;
//    MyInput myInput;
//    public CharacterController characterController;
//    public CameraControl cameraControl;
//    public MainCharacterDataBiding MainCharacterDataBiding;
//    public AimIK aimIK;
//    public static playerStance stance;
//    public float rateOfFire = 2;
//    private float Timer_rof;
//    public float groundOffset;
//    public float groundRadius;
//    public LayerMask groundMask;
//    public float gravityAccel = -9.81f;
//    public float fallSpeed = 100;
//    public float footHeigh = 0.5f;
//    public float jumpHeight;
//    public float jumpTime;
//    private float initialJumpVel;
//    float Jump_timer;
//    public float jumpCooldown;
//    private Vector3 currentMovement;
//    public float runSpeed;
//    private  bool isShooting;
//    public JoystickControl leftJoystickControl;
//    private void Awake()
//    {
//        trans = transform;
//        myInput = MyInputSingleton.Instance.myInput;
//        Timer_rof = rateOfFire;
//        Jump_timer = jumpCooldown;
//        SetJumpVar();
//    }
//    void Update()
//    {
        
//        Vector2 dirMove2D = myInput.Player.Movement.ReadValue<Vector2>();
//        // neu co input tu joystick thi ghi de
//        if (leftJoystickControl.dirMoveJS.sqrMagnitude > 0)
//            dirMove2D = leftJoystickControl.dirMoveJS;
//        MoveCharacter(dirMove2D);
//        BowIK(stance == playerStance.aim);
//        ShootControl(stance == playerStance.aim && myInput.Player.Shoot.IsPressed());
//        GravityHandle(IsGround());
//        HandleJump();
//        characterController.Move(currentMovement * Time.deltaTime);
//    }
//    public void SetJumpVar()
//    {
//        float timetoApex = jumpTime / 2;
//        gravityAccel = (-2 * jumpHeight) / Mathf.Pow(timetoApex, 2);
//        initialJumpVel = (2 * jumpHeight) / timetoApex;
//    }
//    public void HandleJump()
//    {
//        Jump_timer += Time.deltaTime;
//        if (Jump_timer >= jumpCooldown)
//        {
//            if (IsGround() && myInput.Player.Jump.IsPressed())
//            {
//                Jump_timer = 0;
//                currentMovement.y = initialJumpVel;
//            }
//        }
//    }
//    public void ShootControl(bool input)
//    {
//        Timer_rof += Time.deltaTime;
//        if (input)
//        {
//            if (Timer_rof >= rateOfFire)
//            {
//                MainCharacterDataBiding.Shoot = true;
//                isShooting = true;
//                Timer_rof = 0;
//                StartCoroutine(DelayIKWhenShooting());
//            }
//        }
//    }
//    public IEnumerator DelayIKWhenShooting()
//    {
//        yield return new WaitForSeconds(0.7f);//0.7 la thoi gian cua anim shoot
//        isShooting = false;
//    }    
//    public void MoveCharacter(Vector2 input)
//    {
//        // stance animation
//        if (myInput.Player.Crouch.IsPressed())
//        {
//            MainCharacterDataBiding.stance = -1;
//            stance = playerStance.crouch;
//        }
//        else
//        {
//            if (myInput.Player.Aim.IsPressed())
//            {
//                MainCharacterDataBiding.stance = 1;
//                stance = playerStance.aim;
//            }
//            else
//            {
//                MainCharacterDataBiding.stance = 0;
//                stance = playerStance.stand;
//            }
//        }
//        // animation theo huong di chuyen
//        if ((stance == 0) && myInput.Player.Run.IsPressed())

//        {
//            MainCharacterDataBiding.velocity_x = input.x * 2;
//            MainCharacterDataBiding.velocity_z = input.y * 2;
//        }
//        // khi khong Run
//        else
//        {
//            MainCharacterDataBiding.velocity_x = input.x;
//            MainCharacterDataBiding.velocity_z = input.y;
//        }

//        // xoay va move nhan vat
//        RotateCharacter();
//        if (input.sqrMagnitude > 0)
//        {
//            if (IsGround())
//                if (myInput.Player.Run.IsPressed())
//                {
//                    currentMovement.x = DirMoveCharacter(input).x * mainCharacterSpeed * runSpeed;
//                    currentMovement.z = DirMoveCharacter(input).z * mainCharacterSpeed * runSpeed;
//                }
//                else
//                {
//                    currentMovement.x = DirMoveCharacter(input).x * mainCharacterSpeed;
//                    currentMovement.z = DirMoveCharacter(input).z * mainCharacterSpeed;
//                }
//        }
//        else
//        {
//            currentMovement.x = 0;
//            currentMovement.z = 0;
//        }
//        // khi khong cham ground thi ko the dieu khien nhan vat di chuyen
//    }
//    public void RotateCharacter()
//    {
//        float euler_y = trans.eulerAngles.y;
//        Vector3 rawRotattion = cameraControl.trans.localEulerAngles;
//        float rotation_vel = 0;
//        euler_y = Mathf.SmoothDampAngle(euler_y, rawRotattion.y, ref rotation_vel, Time.deltaTime * 10);
//        trans.eulerAngles = new Vector3(0, euler_y, 0);
//    }
//    public Vector3 DirMoveCharacter(Vector2 input)
//    {
//        float rotate_angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
//        Quaternion q = Quaternion.Euler(0, rotate_angle, 0);
//        Vector3 dirMove = q * trans.forward;
//        //dirmove se khong lam thay doi van toc theo phuong Vy cua nhan vat ma chi thay doi van toc Vx,Vz

//        return dirMove;
//    }
//    public void BowIK(bool isAim)
//    {
//        if (isAim)
//        {
//            aimIK.solver.IKPositionWeight = Mathf.Lerp(aimIK.solver.IKPositionWeight, 1, Time.deltaTime * 6);
//        }
//        else aimIK.solver.IKPositionWeight = 0;
//        if (isShooting)
//            aimIK.solver.IKPositionWeight = 0;
//    }

//    private void OnApplicationFocus(bool focus)
//    {
//       // Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
//    }
//    public bool IsGround()
//    {
//        Vector3 groundSphere_pos = new Vector3(trans.position.x, trans.position.y + groundOffset, trans.position.z);
//        bool isGround = Physics.CheckSphere(groundSphere_pos, groundRadius, groundMask, QueryTriggerInteraction.Ignore);
//        return isGround;
//    }
//    public void GravityHandle(bool isGround)
//    {
//        if (isGround && currentMovement.y < 0)// chi van toc <0 moi bi. reset ve 0
//        {
//            currentMovement.y = 0;
//        }
//        else
//        {
//            currentMovement.y += gravityAccel * Time.deltaTime;
//        }
//    }
//}
//public enum playerStance
//{
//    crouch = -1,
//    stand = 0,
//    aim = 1
}
